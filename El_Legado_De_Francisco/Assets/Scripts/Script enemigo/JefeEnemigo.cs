using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeEnemigo : MonoBehaviour
{
    public GameObject minienemigoPrefab;
    public float velocidadMovimiento = 5f;
    public float distanciaDeAccion = 10f;
    public float tiempoEntreGeneraciones = 2.5f;

    private Transform jugador;
    private float tiempoDesdeUltimaGeneracion = 0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calcula la distancia entre el jefe y el jugador
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

        // Si el jugador está dentro del campo de visión
        if (distanciaAlJugador < distanciaDeAccion)
        {
            // Calcula la dirección en la que el jefe debe alejarse
            Vector2 direccionAlejamiento = (transform.position - jugador.position).normalized;

            // Mueve al jefe en la dirección opuesta al jugador
            transform.Translate(direccionAlejamiento * velocidadMovimiento * Time.deltaTime);

            // Incrementa el tiempo desde la última generación
            tiempoDesdeUltimaGeneracion += Time.deltaTime;

            // Si ha pasado el tiempo establecido, genera un nuevo minienemigo
            if (tiempoDesdeUltimaGeneracion >= tiempoEntreGeneraciones)
            {
                GenerarMinienemigo();
                tiempoDesdeUltimaGeneracion = 0f; // Reinicia el contador de tiempo
            }
        }
    }

    void GenerarMinienemigo()
    {
        // Instancia el minienemigo en la posición del jefe
        GameObject minienemigo = Instantiate(minienemigoPrefab, transform.position, Quaternion.identity);

        // Configura el minienemigo para que persiga al jugador
        MinienemigoScript minienemigoScript = minienemigo.GetComponent<MinienemigoScript>();
        if (minienemigoScript != null)
        {
            minienemigoScript.SetJugador(jugador);
        }
    }
}





