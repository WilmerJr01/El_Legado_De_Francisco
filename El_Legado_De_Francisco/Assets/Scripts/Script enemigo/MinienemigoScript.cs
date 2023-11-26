using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinienemigoScript : MonoBehaviour
{
    private Transform jugador;
    public float velocidadMovimiento = 5f;
    public float distanciaMaxima = 5f; // Distancia máxima al jugador

    public BarraDeVida barraDeVida; // Asegúrate de asignar esto en el Inspector
    public float distanciaDeCausarDanio = 1.0f;
    float distanciaAlJugador;

    public void SetJugador(Transform jugadorTransform)
    {
        jugador = jugadorTransform;
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la distancia entre el minienemigo y el jugador
            distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

            // Si la distancia es mayor que la distancia máxima, mueve al minienemigo hacia el jugador
            if (distanciaAlJugador > distanciaMaxima)
            {
                // Calcula la dirección hacia el jugador
                Vector2 direccionAlJugador = (jugador.position - transform.position).normalized;

                // Mueve al minienemigo en la dirección hacia el jugador
                transform.Translate(direccionAlJugador * velocidadMovimiento * Time.deltaTime);
            }
        }

        // Ajusta la condición para aplicar daño
        if (jugador != null && jugador.GetComponent<Collider2D>() != null)
        {
            float radioJugador = jugador.GetComponent<Collider2D>().bounds.size.x / 2f; // Asume que el jugador tiene un collider 2D circular

            if (distanciaAlJugador <= distanciaDeCausarDanio + radioJugador)
            {
                Debug.Log("Jugador lo suficientemente cerca para reducir la vida");
                // Reducir la vida del jugador (ajusta la cantidad de daño según sea necesario)
                barraDeVida.ReducirVida(3.0f * Time.deltaTime);

                // Mensajes de depuración
                Debug.Log("Distancia al jugador: " + distanciaAlJugador);
                Debug.Log("Reduciendo vida...");
            }
        }
    }
}










