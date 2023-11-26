using System.Collections;
using System.Collections.Generic;
// BarraDeVida.cs
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    protected Slider slider;

    private void Start()
    {
        InicializarBarraDeVida(1);
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        slider = GetComponent<Slider>();

        if (slider == null)
        {
            Debug.LogError("No se encontró el componente Slider en el objeto.");
            return;
        }

        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }

    public void ReducirVida(float cantidad)
{
    Debug.Log("Reduciendo vida: " + cantidad);
    slider.value -= cantidad;
}
}
