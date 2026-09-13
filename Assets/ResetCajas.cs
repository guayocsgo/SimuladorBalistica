using UnityEngine;
using System.Collections.Generic;

public class ResetCajas : MonoBehaviour
{
    [Header("Referencia")]
    public Transform contenedorCajas; // el objeto padre "Cajas" que ya tenés en la Hierarchy

    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private List<Vector3> posicionesIniciales = new List<Vector3>();
    private List<Quaternion> rotacionesIniciales = new List<Quaternion>();

    void Start()
    {
        // Guardamos el estado inicial de cada caja apenas arranca el juego
        foreach (Transform caja in contenedorCajas)
        {
            Rigidbody rb = caja.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rigidbodies.Add(rb);
                posicionesIniciales.Add(caja.position);
                rotacionesIniciales.Add(caja.rotation);
            }
        }
    }

    public void Reiniciar()
    {
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            Rigidbody rb = rigidbodies[i];

            // Frenamos cualquier movimiento/rotación que traía
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // La devolvemos a su posición y rotación original
            rb.position = posicionesIniciales[i];
            rb.rotation = rotacionesIniciales[i];
        }
    }
}