using UnityEngine;
using TMPro;
using System.Collections;

public class RegistroDisparos : MonoBehaviour
{
    public static RegistroDisparos Instance { get; private set; }

    [Header("Referencias")]
    public Launcher launcher;
    public Transform contenedorCajas;
    public TMP_Text textoResultado;

    [Header("Configuración")]
    public float tiempoEspera = 2f;
    public float umbralGrados = 30f;

    private int totalDisparos = 0;
    private bool ultimoAcierto = false;
    private float ultimaDistancia = 0f;

    void Awake()
    {
        Instance = this;
    }

    public void RegistrarDisparo()
    {
        totalDisparos++;
        StartCoroutine(ContarYGuardar());
    }

    // Llamado por ImpactoProyectil apenas la bala choca contra algo
    public void NotificarImpacto(bool acierto, float distancia)
    {
        ultimoAcierto = acierto;
        ultimaDistancia = distancia;
    }

    private IEnumerator ContarYGuardar()
    {
        yield return new WaitForSeconds(tiempoEspera);

        int cajasCaidas = 0;
        int cajasTotales = 0;

        foreach (Transform hijo in contenedorCajas)
        {
            Caja caja = hijo.GetComponent<Caja>();
            if (caja != null)
            {
                cajasTotales++;
                if (caja.EstaTumbada(umbralGrados))
                    cajasCaidas++;
            }
        }

        textoResultado.text = $"Disparo #{totalDisparos}: {cajasCaidas}/{cajasTotales} cajas caídas";

        DisparoResultado resultado = new DisparoResultado
        {
            angulo = launcher.angulo,
            anguloHorizontal = launcher.anguloHorizontal,
            fuerza = launcher.ultimaFuerzaReal,
            masaProyectil = launcher.ultimaMasaProyectil,
            acierto = ultimoAcierto,
            distancia = ultimaDistancia,
            objetosAfectados = cajasCaidas,
            fecha = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        };

        if (UGSManager.Instance != null)
            await_GuardarSeguro(resultado);
    }

    private async void await_GuardarSeguro(DisparoResultado resultado)
    {
        await UGSManager.Instance.GuardarDisparo(resultado);
    }

    public void ReiniciarContador()
    {
        totalDisparos = 0;
        textoResultado.text = "";
    }
}