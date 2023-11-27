using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorScript : MonoBehaviour
{
    public float distanciaAtaque = 1f;
    public LayerMask capaMinienemigo;
    public int contadorGolpes;
    public float distanciaMaximaParaContador = 2.0f;
    [SerializeField] private PuntajeJugador puntaje;

    public int empuje=-3;

    void Update()
    {
        // Obtiene la dirección del jugador según la entrada de teclado
        float direccionX = Input.GetAxisRaw("Horizontal");

        // Verifica si el jugador presiona la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Obtiene la dirección local hacia la derecha o izquierda del objeto del jugador
            Vector2 direccionLocal = new Vector2(direccionX, 0f);

            // Calcula la posición del punto de ataque
            Vector2 puntoDeAtaque = (Vector2)transform.position + direccionLocal * distanciaAtaque;

            // Realiza un overlapCircle en el punto de ataque para detectar minienemigos
            Collider2D[] minienemigos = Physics2D.OverlapCircleAll(puntoDeAtaque, 0.1f, capaMinienemigo);

            // Itera sobre todos los minienemigos y elimínalos si están en la dirección correcta
            foreach (Collider2D minienemigoCollider in minienemigos)
            {
                MinienemigoScript minienemigo = minienemigoCollider.GetComponent<MinienemigoScript>();
                
                if (minienemigo != null)
                {
                    // Obtiene la dirección hacia el minienemigo
                    Vector2 direccionAlMinienemigo = minienemigo.transform.position - transform.position;

                    // Normaliza las direcciones para asegurarse de que estén normalizadas
                    Vector2 direccionNormalizada = direccionLocal.normalized;
                    Vector2 direccionAlMinienemigoNormalizada = direccionAlMinienemigo.normalized;

                    // Calcula el producto punto
                    float productoPunto = Vector2.Dot(direccionNormalizada, direccionAlMinienemigoNormalizada);

                    // Verifica si el jugador está mirando hacia el minienemigo (ajusta este valor según sea necesario)
                    if (productoPunto > 0.7f)
                    {
                        // Elimina el minienemigo
                        Destroy(minienemigo.gameObject);
                        puntaje.SumarPuntos(10f); //Puntos del jugador al matar un minienemigo
                    }
                }
            }
        }

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JefeEnemigo"))
        {
            // Verifica la distancia al jugador antes de contar el golpe
            float distanciaAlEnemigo = Vector2.Distance(transform.position, collision.transform.position);

            if (distanciaAlEnemigo <= distanciaMaximaParaContador && Input.GetKey(KeyCode.P))
            {
                // Aumenta el contador de golpes
                contadorGolpes++;
                SpriteRenderer jefeSpriteRenderer = collision.GetComponent<SpriteRenderer>();
                if (jefeSpriteRenderer != null)
                {
                    jefeSpriteRenderer.color = Color.red;
                    Invoke("RestaurarColor", 1f);
                    RespuestaEnemigo();

                }
                // Imprime el contador en la consola
                Debug.Log("Golpe al JefeEnemigo. Contador: " + contadorGolpes);

                if (contadorGolpes == 5)
                {
                    Destroy(collision.gameObject);
                        puntaje.SumarPuntos(100f);

                    //Cambiarde escena 
                    //SceneManager.LoadScene("Score");
                }
            }
        }
    }

    void RestaurarColor()
    {
        // Recuperar el jefe de la jerarquía o mediante algún otro método
        GameObject jefe = GameObject.FindGameObjectWithTag("JefeEnemigo");

        // Verificar si el jefe es válido antes de intentar obtener el SpriteRenderer
        if (jefe != null)
        {
            SpriteRenderer jefeSpriteRenderer = jefe.GetComponent<SpriteRenderer>();
            if (jefeSpriteRenderer != null)
            {
                // Restablece el color a su valor original (blanco en este caso, ajusta según tus necesidades)
                jefeSpriteRenderer.color = Color.white;
            }
        }
    }
    void RespuestaEnemigo()
    {
        GameObject jefe = GameObject.FindGameObjectWithTag("JefeEnemigo");
        if (jefe != null)
        {
            JefeEnemigo jefe1 = jefe.GetComponent<JefeEnemigo>();
            jefe1.velocidadMovimiento = 4;
            Invoke("restaurarEnemigo", 1f);
        }

    }
    void restaurarEnemigo()
    {
        GameObject jefe = GameObject.FindGameObjectWithTag("JefeEnemigo");
        if (jefe != null)
        {
            JefeEnemigo jefe1 = jefe.GetComponent<JefeEnemigo>();
            jefe1.velocidadMovimiento = 2;
           
        }
    }
     public void Retroceder()
    {
        // Puedes ajustar la fuerza de retroceso según tus necesidades
        Transform miTransform = transform;

        miTransform.Translate(Vector3.right*empuje*Time.deltaTime,Space.World);
       
    }

   public void CambiarColorJugador(Color color)
{
    SpriteRenderer jugadorSpriteRenderer = GetComponent<SpriteRenderer>();
    if (jugadorSpriteRenderer != null)
    {
        jugadorSpriteRenderer.color = color;

        // Inicia un temporizador para cambiar de nuevo el color después de 1 segundo
        StartCoroutine(AlternarColor());
    }
}

    // Función para alternar el color del jugador
    IEnumerator AlternarColor()
    {
        yield return new WaitForSeconds(0.5f);

        // Cambia el color del jugador a blanco
        CambiarColorJugador(Color.white);
    }

    // ... (resto de tu código)
}






































