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

    private int contadorGolpes = 0;
    public float distanciaMaximaParaContador = 2.0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (contadorGolpes == 5)
    {
        // Destruir el jefe
        Destroy(gameObject);
    }
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

        if (distanciaAlJugador < distanciaDeAccion)
        {
            // Obtiene el siguiente punto de destino del jefe
            Vector2 destino = puntosDestino[indiceDestinoActual].position;

            // Mueve al jefe hacia el punto de destino
            transform.position = Vector2.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);

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

    void GenerarMinienemigo()
    {
        GameObject minienemigo = Instantiate(minienemigoPrefab, transform.position, Quaternion.identity);
        MinienemigoScript minienemigoScript = minienemigo.GetComponent<MinienemigoScript>();

        if (minienemigoScript != null)
        {
            minienemigoScript.SetJugador(jugador);
        }
    }

    // Método para manejar el ataque del jugador al jefe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Verifica la distancia al jugador antes de contar el golpe
            float distanciaAlJugador = Vector2.Distance(transform.position, collision.transform.position);

            if (distanciaAlJugador <= distanciaMaximaParaContador)
            {
                // Aumenta el contador de golpes
                contadorGolpes++;

                // Imprime el contador en la consola
                Debug.Log("Golpe al JefeEnemigo. Contador: " + contadorGolpes);
            }
        }
    }
}

    
























