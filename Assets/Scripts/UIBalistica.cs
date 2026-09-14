using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBalistica : MonoBehaviour
{
    public Launcher launcher;
    public Slider sliderPotencia;
    public Slider sliderAngulo;
    public Slider sliderAnguloHorizontal;
    public TMP_Dropdown dropdownProyectil;
    public TMP_Text textoPotencia;
    public TMP_Text textoAngulo;
    public TMP_Text textoAnguloHorizontal;

    void Start()
    {
        sliderPotencia.onValueChanged.AddListener(OnPotenciaChanged);
        sliderAngulo.onValueChanged.AddListener(OnAnguloChanged);
        sliderAnguloHorizontal.onValueChanged.AddListener(OnAnguloHorizontalChanged);
        dropdownProyectil.onValueChanged.AddListener(OnProyectilChanged);

        sliderAngulo.minValue = 0f;
        sliderAngulo.maxValue = 90f;
        sliderAnguloHorizontal.minValue = -45f;
        sliderAnguloHorizontal.maxValue = 45f;
        sliderAnguloHorizontal.value = 0f;

        OnPotenciaChanged(sliderPotencia.value);
        OnAnguloChanged(sliderAngulo.value);
        OnAnguloHorizontalChanged(sliderAnguloHorizontal.value);
        OnProyectilChanged(dropdownProyectil.value);
    }

    void OnPotenciaChanged(float valor)
    {
        launcher.SetPotencia(valor);
        textoPotencia.text = $"Potencia: {Mathf.RoundToInt(valor * 100)}%";
    }

    void OnAnguloChanged(float valor)
    {
        launcher.SetAngulo(valor);
        textoAngulo.text = $"Ángulo: {valor:F0}°";
    }

    void OnAnguloHorizontalChanged(float valor)
    {
        launcher.SetAnguloHorizontal(valor);
        textoAnguloHorizontal.text = $"Dirección: {valor:F0}°";
    }

    void OnProyectilChanged(int indice)
    {
        launcher.SetTipoProyectil(indice);
    }
}