using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    public float distanciaAtaque = 1f;
    public LayerMask capaMinienemigo;
    public int contadorGolpes;
    public float distanciaMaximaParaContador = 2.0f;

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

                // Imprime el contador en la consola
                Debug.Log("Golpe al JefeEnemigo. Contador: " + contadorGolpes);

                if (contadorGolpes == 5)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}




































