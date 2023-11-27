using System.Collections;
using System.Collections.Generic;
// BarraDeVida.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    protected Slider slider;
    public Combate_Jugador jugador;


    private void Start()
    {
        InicializarBarraDeVida(1);
    }
    void Update()
    {
        GameObject jefe = GameObject.FindGameObjectWithTag("JefeEnemigo");
        if (jugador != null)
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);

        }
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

        slider.value -= cantidad;
    }
    private void OnSliderValueChanged(float value)
    {
        if (value <= 0f)
        {
            // El Slider ha llegado a cero
            Debug.Log("El Slider ha llegado a cero.");
            SceneManager.LoadScene("Scores");

            // Puedes poner aquí el código que quieras ejecutar cuando el Slider llega a cero
        }
    }
}
