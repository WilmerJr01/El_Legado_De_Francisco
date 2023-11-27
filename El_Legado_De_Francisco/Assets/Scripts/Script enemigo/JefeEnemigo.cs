using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeEnemigo : MonoBehaviour
{
    public GameObject minienemigoPrefab;
    public float velocidadMovimiento = 5f;
    public float distanciaDeAccion = 10f;
    public float tiempoEntreGeneraciones = 2.5f;

    // Lista de puntos de destino del jefe
    public List<Transform> puntosDestino;
    private int indiceDestinoActual = 0;

    private Transform jugador;
    private float tiempoDesdeUltimaGeneracion = 0f;
    public float distanciaMaximaParaContador = 2.0f;

    public bool vivo = true;

    // Variable para controlar la dirección del jefe
    private int direccion = 1; // 1 para derecha, -1 para izquierda

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (jugador != null)
        {
            float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

            if (distanciaAlJugador < distanciaDeAccion)
            {
                // Obtiene el siguiente punto de destino del jefe
                Vector2 destino = puntosDestino[indiceDestinoActual].position;

                // Mueve al jefe hacia el punto de destino
                transform.position = Vector2.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);

                // Verificar y actualizar la dirección del jefe

                // Reflejar el sprite horizontalmente según la dirección
                transform.localScale = new Vector3(direccion, 1, 1);

                tiempoDesdeUltimaGeneracion += Time.deltaTime;

                if (tiempoDesdeUltimaGeneracion >= tiempoEntreGeneraciones)
                {
                    GenerarMinienemigo();
                    tiempoDesdeUltimaGeneracion = 0f;
                }

                // Verificar si el jefe ha alcanzado su destino actual
                if (Vector2.Distance(transform.position, destino) < 0.1f)
                {
                    // Cambiar al siguiente punto de destino
                    indiceDestinoActual = (indiceDestinoActual + 1) % puntosDestino.Count;
                }
            }
        }





    }

    void GenerarMinienemigo()
    {
        GameObject minienemigo = Instantiate(minienemigoPrefab, transform.position, Quaternion.identity);
        MinienemigoScript minienemigoScript = minienemigo.GetComponent<MinienemigoScript>();

        if (minienemigoScript != null)
        {
            minienemigoScript.SetJugador(jugador);
        }
    }
    public void aumentarDificultad()
    {
        velocidadMovimiento = 5 + velocidadMovimiento;
        tiempoEntreGeneraciones -= 3f;
    }

    // Método para manejar el ataque del jugador al jefe
}
































