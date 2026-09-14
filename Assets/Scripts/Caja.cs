using UnityEngine;

public class Caja : MonoBehaviour
{
    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    public bool EstaTumbada(float umbralGrados = 30f)
    {
        return Quaternion.Angle(rotacionInicial, transform.rotation) > umbralGrados;
    }
}