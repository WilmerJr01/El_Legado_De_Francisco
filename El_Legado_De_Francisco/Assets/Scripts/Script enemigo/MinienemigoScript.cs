using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinienemigoScript : MonoBehaviour
{
    private Transform jugador;
    public float velocidadMovimiento = 5f;
    public float distanciaMaxima = 5f; // Distancia máxima al jugador

    public void SetJugador(Transform jugadorTransform)
    {
        jugador = jugadorTransform;
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcula la distancia entre el minienemigo y el jugador
            float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

            // Si la distancia es mayor que la distancia máxima, mueve al minienemigo hacia el jugador
            if (distanciaAlJugador > distanciaMaxima)
            {
                // Calcula la dirección hacia el jugador
                Vector2 direccionAlJugador = (jugador.position - transform.position).normalized;

                // Mueve al minienemigo en la dirección hacia el jugador
                transform.Translate(direccionAlJugador * velocidadMovimiento * Time.deltaTime);
            }
        }
    }
}








