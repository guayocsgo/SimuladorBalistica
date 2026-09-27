
using UnityEngine;

public class ImpactoProyectil : MonoBehaviour
{
    public GameObject efectoImpactoPrefab;

    [HideInInspector] public Vector3 puntoOrigen; 

    void OnCollisionEnter(Collision collision)
    {
        if (efectoImpactoPrefab != null)
        {
            ContactPoint contacto = collision.GetContact(0);
            Instantiate(efectoImpactoPrefab, contacto.point, Quaternion.identity);

            
            bool acierto = collision.gameObject.CompareTag("Caja");
            float distancia = Vector3.Distance(puntoOrigen, contacto.point);

            if (RegistroDisparos.Instance != null)
                RegistroDisparos.Instance.NotificarImpacto(acierto, distancia);
        }

        Destroy(gameObject);
    }
}