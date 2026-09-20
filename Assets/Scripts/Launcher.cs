//using UnityEngine;

//public class Launcher : MonoBehaviour
//{
//    [Header("Referencias")]
//    public GameObject[] proyectilesPrefabs; 
//    public Transform puntoDisparo;

//    [Header("Configuración")]
//    public float potenciaMin = 5f;
//    public float potenciaMax = 30f;
//    public float anguloMin = 0f;
//    public float anguloMax = 90f;
//    public float anguloHorizontalMin = -45f;
//    public float anguloHorizontalMax = 45f;

//    [Header("Valores actuales (controlados por UI)")]
//    [Range(0f, 1f)] public float potenciaNormalizada = 0.5f;
//    [Range(0f, 90f)] public float angulo = 45f;
//    [Range(-45f, 45f)] public float anguloHorizontal = 0f;

//    private int indiceProyectilActual = 0;

//    public void SetPotencia(float valor01) => potenciaNormalizada = valor01;
//    public void SetAngulo(float valorAngulo) => angulo = valorAngulo;
//    public void SetAnguloHorizontal(float valorAngulo) => anguloHorizontal = valorAngulo;

//    public void SetTipoProyectil(int indice)
//    {
//        if (indice >= 0 && indice < proyectilesPrefabs.Length)
//            indiceProyectilActual = indice;
//    }

//    public Vector3 CalcularDireccion()
//    {
//        Quaternion rotacion = Quaternion.Euler(-angulo, puntoDisparo.eulerAngles.y + anguloHorizontal, 0f);
//        return rotacion * Vector3.forward;
//    }

//    public void Disparar()
//    {
//        if (proyectilesPrefabs.Length == 0) return;

//        float potencia = Mathf.Lerp(potenciaMin, potenciaMax, potenciaNormalizada);
//        Vector3 direccion = CalcularDireccion();

//        GameObject prefabElegido = proyectilesPrefabs[indiceProyectilActual];

//        Quaternion rotacionProyectil = Quaternion.LookRotation(direccion);
//        GameObject proyectil = Instantiate(prefabElegido, puntoDisparo.position, rotacionProyectil);
//        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
//        rb.linearVelocity = direccion.normalized * potencia;
//    }
//}
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject[] proyectilesPrefabs; // los distintos tipos de proyectil
    public Transform puntoDisparo;

    [Header("Configuración")]
    public float potenciaMin = 5f;
    public float potenciaMax = 30f;
    public float anguloMin = 0f;
    public float anguloMax = 90f;
    public float anguloHorizontalMin = -45f;
    public float anguloHorizontalMax = 45f;

    [Header("Valores actuales (controlados por UI)")]
    [Range(0f, 1f)] public float potenciaNormalizada = 0.5f;
    [Range(0f, 90f)] public float angulo = 45f;
    [Range(-45f, 45f)] public float anguloHorizontal = 0f;

    [Header("Datos del último disparo (para el registro)")]
    public float ultimaFuerzaReal;
    public float ultimaMasaProyectil;

    private int indiceProyectilActual = 0;

    public void SetPotencia(float valor01) => potenciaNormalizada = valor01;
    public void SetAngulo(float valorAngulo) => angulo = valorAngulo;
    public void SetAnguloHorizontal(float valorAngulo) => anguloHorizontal = valorAngulo;

    public void SetTipoProyectil(int indice)
    {
        if (indice >= 0 && indice < proyectilesPrefabs.Length)
            indiceProyectilActual = indice;
    }

    public Vector3 CalcularDireccion()
    {
        Quaternion rotacion = Quaternion.Euler(-angulo, puntoDisparo.eulerAngles.y + anguloHorizontal, 0f);
        return rotacion * Vector3.forward;
    }

    public void Disparar()
    {
        if (proyectilesPrefabs.Length == 0) return;

        float potencia = Mathf.Lerp(potenciaMin, potenciaMax, potenciaNormalizada);
        Vector3 direccion = CalcularDireccion();
        Quaternion rotacionProyectil = Quaternion.LookRotation(direccion);

        GameObject prefabElegido = proyectilesPrefabs[indiceProyectilActual];
        GameObject proyectil = Instantiate(prefabElegido, puntoDisparo.position, rotacionProyectil);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.linearVelocity = direccion.normalized * potencia;

        // Guardamos los datos de este disparo para el registro (UGS)
        ultimaFuerzaReal = potencia;
        ultimaMasaProyectil = rb.mass;

        // Le avisamos al ImpactoProyectil desde dónde salió, para calcular distancia al impactar
        ImpactoProyectil impacto = proyectil.GetComponent<ImpactoProyectil>();
        if (impacto != null)
            impacto.puntoOrigen = puntoDisparo.position;
    }
}