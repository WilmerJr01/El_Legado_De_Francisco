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
    public float umbralCambioDireccion = 0.5f; // Ajusta según sea necesario
    private Animator playerAnimator;


    public void SetJugador(Transform jugadorTransform)
    {
        jugador = jugadorTransform;

    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
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
                playerAnimator.SetFloat("Speed", velocidadMovimiento);

                playerAnimator.SetFloat("Horizontal", direccionAlJugador.x);
                if (direccionAlJugador.x != 0)
                {
                    float auxX = direccionAlJugador.x;
                    playerAnimator.SetFloat("Vertical", auxX);
                }

                // Cambia la dirección solo si ha cambiado y la distancia es mayor que el umbral
               
        }

        // Ajusta la condición para aplicar daño
        if (jugador != null && jugador.GetComponent<Collider2D>() != null)
        {
            float radioJugador = jugador.GetComponent<Collider2D>().bounds.size.x / 2f; // Asume que el jugador tiene un collider 2D circular

            if (distanciaAlJugador <= distanciaDeCausarDanio + radioJugador)
            {
                // Reducir la vida del jugador (ajusta la cantidad de daño según sea necesario)
                barraDeVida.ReducirVida(3.0f * Time.deltaTime);
                GameObject objplayer = GameObject.FindGameObjectWithTag("Player");
                JugadorScript player = objplayer.GetComponent<JugadorScript>();
                player.CambiarColorJugador(Color.red);
                //player.Retroceder();

                //enemigo se aleja al causar daño
                //Transform miTransform = transform;

        // Modificar la posición en el eje X
       // float distanciaMaximaMovimiento = 0.5f; // Ajusta el valor según sea necesario
       // float nuevaPosicionX = Mathf.Clamp(miTransform.position.x + 0.1f, miTransform.position.x - distanciaMaximaMovimiento, miTransform.position.x + distanciaMaximaMovimiento);

        // Aplicar la nueva posición
        //miTransform.position = new Vector3(nuevaPosicionX, miTransform.position.y, miTransform.position.z);

                // Mensajes de depuración
            }
        }
        
    }
}
}















