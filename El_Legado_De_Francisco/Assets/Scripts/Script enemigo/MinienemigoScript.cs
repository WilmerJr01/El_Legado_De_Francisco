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
    private float distanciaAlJugador;
    private bool mirandoDerecha = true; // Asumimos que inicialmente está mirando hacia la derecha
    public float umbralCambioDireccion = 0.5f; // Ajusta según sea necesario

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

                // Cambia la dirección solo si ha cambiado y la distancia es mayor que el umbral
                if (direccionAlJugador.x > 0 && !mirandoDerecha && Mathf.Abs(direccionAlJugador.x) > umbralCambioDireccion)
                {
                    // Mira hacia la derecha
                    mirandoDerecha = true;
                }
                else if (direccionAlJugador.x < 0 && mirandoDerecha && Mathf.Abs(direccionAlJugador.x) > umbralCambioDireccion)
                {
                    // Mira hacia la izquierda
                    mirandoDerecha = false;
                }
            }
        }

        // Ajusta la condición para aplicar daño
        if (jugador != null && jugador.GetComponent<Collider2D>() != null)
        {
            float radioJugador = jugador.GetComponent<Collider2D>().bounds.size.x / 2f; // Asume que el jugador tiene un collider 2D circular

            if (distanciaAlJugador <= distanciaDeCausarDanio + radioJugador)
            {
                // Reducir la vida del jugador (ajusta la cantidad de daño según sea necesario)
                barraDeVida.ReducirVida(3.0f * Time.deltaTime);

                // Mensajes de depuración
            }
        }
    }
}















