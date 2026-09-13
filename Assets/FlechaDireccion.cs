using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FlechaDireccion : MonoBehaviour
{
    public Launcher launcher;
    public Transform puntoDisparo;

    public float longitud = 5f;
    public Color colorFlecha = Color.red;

    private LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = colorFlecha;
        lr.endColor = colorFlecha;
        lr.useWorldSpace = true;
    }

    void Update()
    {
        Vector3 direccion = launcher.CalcularDireccion();
        Vector3 inicio = puntoDisparo.position;
        Vector3 fin = inicio + direccion.normalized * longitud;

        lr.SetPosition(0, inicio);
        lr.SetPosition(1, fin);
    }
}