using UnityEngine;

[RequireComponent(typeof(Light))]
public class PuntoImpacto : MonoBehaviour
{
    public float duracion = 0.3f;
    public float intensidadInicial = 8f;

    private Light luz;
    private float tiempoTranscurrido = 0f;

    void Awake()
    {
        luz = GetComponent<Light>();
        luz.intensity = intensidadInicial;
        Destroy(gameObject, duracion);
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        float progreso = tiempoTranscurrido / duracion;
        luz.intensity = Mathf.Lerp(intensidadInicial, 0f, progreso);
    }
}