//using UnityEngine;

//public class ImpactoProyectil : MonoBehaviour
//{
//    public GameObject efectoImpactoPrefab;

//    void OnCollisionEnter(Collision collision)
//    {
//        if (efectoImpactoPrefab != null)
//        {
//            ContactPoint contacto = collision.GetContact(0);
//            Instantiate(efectoImpactoPrefab, contacto.point, Quaternion.identity);
//        }

//        Destroy(gameObject);
//    }
//}
using UnityEngine;

public class ImpactoProyectil : MonoBehaviour
{
    public GameObject efectoImpactoPrefab;

    [HideInInspector] public Vector3 puntoOrigen; // lo setea el Launcher al disparar

    void OnCollisionEnter(Collision collision)
    {
        if (efectoImpactoPrefab != null)
        {
            ContactPoint contacto = collision.GetContact(0);
            Instantiate(efectoImpactoPrefab, contacto.point, Quaternion.identity);

            // Avisamos al gestor de registro con los datos del impacto
            bool acierto = collision.gameObject.CompareTag("Caja");
            float distancia = Vector3.Distance(puntoOrigen, contacto.point);

            if (RegistroDisparos.Instance != null)
                RegistroDisparos.Instance.NotificarImpacto(acierto, distancia);
        }

        Destroy(gameObject);
    }
}