using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;

public class UGSManager : MonoBehaviour
{
    public static UGSManager Instance { get; private set; }
    private const string CLAVE_HISTORIAL = "historialDisparos";

    private bool inicializado = false;

    async void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        await InicializarUGS();
    }

    private async Task InicializarUGS()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
                await AuthenticationService.Instance.SignInAnonymouslyAsync();

            inicializado = true;
            Debug.Log("UGS listo. PlayerID: " + AuthenticationService.Instance.PlayerId);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error inicializando UGS: " + e);
        }
    }

    public async Task GuardarDisparo(DisparoResultado nuevoDisparo)
    {
        if (!inicializado) await InicializarUGS();

        HistorialDisparos historial = await CargarHistorial();
        historial.disparos.Add(nuevoDisparo);

        string json = JsonUtility.ToJson(historial);
        var data = new Dictionary<string, object> { { CLAVE_HISTORIAL, json } };

        try
        {
            await CloudSaveService.Instance.Data.Player.SaveAsync(data);
            Debug.Log("Disparo guardado en UGS.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error guardando en UGS: " + e);
        }
    }

    public async Task<HistorialDisparos> CargarHistorial()
    {
        if (!inicializado) await InicializarUGS();

        try
        {
            var claves = new HashSet<string> { CLAVE_HISTORIAL };
            var resultado = await CloudSaveService.Instance.Data.Player.LoadAsync(claves);

            if (resultado.TryGetValue(CLAVE_HISTORIAL, out var item))
            {
                string json = item.Value.GetAs<string>();
                return JsonUtility.FromJson<HistorialDisparos>(json);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error cargando de UGS: " + e);
        }

        return new HistorialDisparos();
    }
}