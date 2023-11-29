using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Diablo : MonoBehaviour
{
    public Combate_Jugador jugador1;
    private JugadorScript jugador2;
    public float velocidadMovimiento = 5f;
    public float distanciaDeAccion = 10f;
    public float distanciaRespetoArea = 3f; // Nueva variable para la distancia de respeto

    private Transform jugador;
    public bool inicio = false;

    public GameObject proyectilPrefab; // Prefab del proyectil
    public float velocidadProyectil = 10f;
    public float tiempoDeVidaProyectil = 3f;

    private int proyectilesGenerados;
    private float tiempoUltimoDisparo;
    public int maxProyectiles = 3;
    public float tiempoEntreDisparos = 1f;

    public bool timing = true;
    private Animator diabloAnimator;
    private float speed;
    private bool isAttacking;


    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        jugador2 = GetComponent<JugadorScript>();
        diabloAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jugador != null)
        {
            float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

            // Verificar si el jugador está dentro del rango de acción
            if (distanciaAlJugador < distanciaDeAccion)
            {
                inicio = true;

                // Obtener la dirección hacia el jugador
                Vector2 direccionAlJugador = (jugador.position - transform.position).normalized;

                if (direccionAlJugador.x < 0)
                {
                    diabloAnimator.SetFloat("Horizontal", -1);
                }
                else if (direccionAlJugador.x > 0)
                {
                    diabloAnimator.SetFloat("Horizontal", 1);
                }
                else
                {
                    diabloAnimator.SetFloat("Horizontal", 0);
                }
                speed = 1;
                if (direccionAlJugador.x != 0)
                {
                    if (direccionAlJugador.x < 0)
                    {
                        diabloAnimator.SetFloat("Vertical", -1);
                    }
                    else if (direccionAlJugador.x > 0)
                    {
                        diabloAnimator.SetFloat("Vertical", 1);
                    }
                }

                // Verificar si el jefe está lo suficientemente lejos del jugador para moverse
                if (distanciaAlJugador > distanciaRespetoArea)
                {
                    // Mover al jefe hacia el jugador
                    transform.Translate(direccionAlJugador * velocidadMovimiento * Time.deltaTime);
                    isAttacking = false;
                    diabloAnimator.SetBool("isAttacking", isAttacking);
                    diabloAnimator.SetFloat("Speed", speed);
                }

                // Reflejar el sprite horizontalmente según la dirección
               // if (direccionAlJugador.x > 0)
                 //   transform.localScale = new Vector3(1, 1, 1);
                //else
                  //  transform.localScale = new Vector3(-1, 1, 1);

                if (distanciaAlJugador <= distanciaRespetoArea)
                {

                    if (timing)
                    {
                        timing = false;
                        Invoke("Daño_cuerpo", 0.8f);
                        Invoke("Actualizar_timing", 1.31f);
                    }

                }
            }
            else
            {
                if (inicio)
                {
                    speed = 0;
                    diabloAnimator.SetFloat("Speed", speed);
                    Invoke("ActualizarDisparos", 0.5f);
                }
            }
        }
    }

    void DispararProyectiles()
    {
        // Crear un proyectil y establecer su posición inicial
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
        // Obtener la dirección hacia el jugador
        Vector2 direccionAlJugador = (jugador.position - transform.position).normalized;

        // Aplicar velocidad al proyectil en la dirección del jugador
        proyectil.GetComponent<Rigidbody2D>().velocity = direccionAlJugador * velocidadProyectil;

        // Destruir el proyectil después de cierto tiempo
        Destroy(proyectil, tiempoDeVidaProyectil);
    }
    void ActualizarDisparos()
    {
        // Verificar si ha pasado suficiente tiempo desde el último disparo y si no hemos alcanzado el máximo de proyectiles generados
        if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos && proyectilesGenerados < maxProyectiles)
        {
            
            DispararProyectiles();
            // Actualizar el tiempo del último disparo
            tiempoUltimoDisparo = Time.time;
            // Incrementar el contador de proyectiles generados
            proyectilesGenerados++;
        }
    }
    void Daño_cuerpo()
    {
        jugador1.TomarDaño(20);
        isAttacking = true;
        diabloAnimator.SetBool("isAttacking", isAttacking);
        GameObject objplayer = GameObject.FindGameObjectWithTag("Player");
        JugadorScript player = objplayer.GetComponent<JugadorScript>();
        player.CambiarColorJugador(Color.red);

    }
    void Actualizar_timing()
    {
        timing = true;
    }
    public void CambiarColorDiablo(Color color)
    {
        SpriteRenderer diablo = GetComponent<SpriteRenderer>();
        if (diablo != null)
        {
            diablo.color = color;

            // Inicia un temporizador para cambiar de nuevo el color después de 1 segundo
            StartCoroutine(AlternarColor());
        }
    }

    // Función para alternar el color del jugador
    IEnumerator AlternarColor()
    {
        yield return new WaitForSeconds(0.2f);

        // Cambia el color del jugador a blanco
        CambiarColorDiablo(Color.white);
    }

}

