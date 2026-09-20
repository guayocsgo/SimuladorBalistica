using UnityEngine;
using TMPro;
using System.Text;

public class PanelHistorial : MonoBehaviour
{
    public GameObject panel; // el panel completo que se muestra/oculta
    public TMP_Text textoHistorial;

    public async void MostrarHistorial()
    {
        panel.SetActive(true);
        textoHistorial.text = "Cargando...";

        HistorialDisparos historial = await UGSManager.Instance.CargarHistorial();

        if (historial.disparos.Count == 0)
        {
            textoHistorial.text = "Todavía no hay disparos guardados.";
            return;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < historial.disparos.Count; i++)
        {
            DisparoResultado d = historial.disparos[i];
            sb.AppendLine($"<b>Disparo {i + 1}</b> - {d.fecha}");
            sb.AppendLine($"Ángulo: {d.angulo:F0}° | Horizontal: {d.anguloHorizontal:F0}°");
            sb.AppendLine($"Fuerza: {d.fuerza:F1} | Masa: {d.masaProyectil:F1}");
            sb.AppendLine($"{(d.acierto ? "✔ Acierto" : "✘ Falló")} | Distancia: {d.distancia:F1}m | Objetos afectados: {d.objetosAfectados}");
            sb.AppendLine("――――――――――");
        }

        textoHistorial.text = sb.ToString();
    }

    public void CerrarPanel()
    {
        panel.SetActive(false);
    }
}