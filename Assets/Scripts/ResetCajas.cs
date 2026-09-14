using UnityEngine;
using System.Collections.Generic;

public class ResetCajas : MonoBehaviour
{
    [Header("Referencia")]
    public Transform contenedorCajas; 

    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private List<Vector3> posicionesIniciales = new List<Vector3>();
    private List<Quaternion> rotacionesIniciales = new List<Quaternion>();

    void Start()
    {
       
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

            
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            
            rb.position = posicionesIniciales[i];
            rb.rotation = rotacionesIniciales[i];
        }
    }
}