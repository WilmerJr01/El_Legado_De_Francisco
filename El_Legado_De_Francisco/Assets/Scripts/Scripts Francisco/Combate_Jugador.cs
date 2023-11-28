using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combate_Jugador : MonoBehaviour
{

    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private GameObject vidasRestantes;

    private bool isDead = false;

    // Start is called before the first frame update
    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
        vidasRestantes.SetActive(false);
    }

    public void TomarDaño(float daño)
    {
        if (!isDead)  // Verifica si el jugador no está muerto
        {
            vida -= daño;
            barraDeVida.CambiarVidaActual(vida);

            if (vida <= 0)
            {
                isDead = true;  // El jugador está muerto, evita más daño
                ControladorVidas.Instance.SumarVidas(1);

                if (int.Parse(ControladorVidas.Instance.setVidas()) <= 2)
                {
                    vidasRestantes.SetActive(true);
                    Invoke("RecargarEscena", 3f);
                }
                else
                {
                    SceneManager.LoadScene(4);
                }
            }
        }
    }

    public void RecargarEscena()
    {
        isDead = false;  // Reinicia la bandera de muerte para permitir daño en la siguiente vida
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Curar(float curacion)
    {
        if ((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }

        // Agrega esta línea para actualizar la barra de vida
        barraDeVida.CambiarVidaActual(vida);
    }

    // Update is called once per fram
}
