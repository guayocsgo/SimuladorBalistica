using UnityEngine;

public class ImpactoProyectil : MonoBehaviour
{
    public GameObject efectoImpactoPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (efectoImpactoPrefab != null)
        {
            ContactPoint contacto = collision.GetContact(0);
            Instantiate(efectoImpactoPrefab, contacto.point, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}