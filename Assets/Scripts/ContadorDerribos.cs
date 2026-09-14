using UnityEngine;
using TMPro;
using System.Collections;

public class ContadorDerribos : MonoBehaviour
{
    [Header("Referencias")]
    public Transform contenedorCajas;
    public TMP_Text textoResultado;

    [Header("Configuración")]
    public float tiempoEspera = 2f; 
    public float umbralGrados = 30f;

    private int totalDisparos = 0;

    public void RegistrarDisparo()
    {
        totalDisparos++;
        StartCoroutine(ContarDespuesDeEspera());
    }

    private IEnumerator ContarDespuesDeEspera()
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
    }

    public void ReiniciarContador()
    {
        totalDisparos = 0;
        textoResultado.text = "";
    }
}