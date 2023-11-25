using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    public float distanciaAtaque = 1.5f;
    public LayerMask capaMinienemigo;
    public float anguloPermitido = 45f; // Ángulo permitido para el ataque

    void Update()
    {
        // Verifica si el jugador presiona la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Detecta minienemigos en la posición del jugador
            Collider2D[] minienemigos = Physics2D.OverlapCircleAll(transform.position, distanciaAtaque, capaMinienemigo);

            // Itera sobre todos los minienemigos y elimínalos si el jugador está mirando en su dirección
            foreach (Collider2D minienemigoCollider in minienemigos)
            {
                MinienemigoScript minienemigo = minienemigoCollider.GetComponent<MinienemigoScript>();

                if (minienemigo != null)
                {
                    // Calcula la dirección al minienemigo
                    Vector2 direccionAlMinienemigo = (minienemigo.transform.position - transform.position).normalized;

                    // Calcula el ángulo entre la dirección de mira del jugador y la dirección al minienemigo
                    float anguloDerecha = Vector2.Angle(transform.right, direccionAlMinienemigo);
                    float anguloIzquierda = Vector2.Angle(-transform.right, direccionAlMinienemigo);

                    // Si el ángulo es menor que el permitido en ambas direcciones, el jugador está mirando hacia el minienemigo
                    if (anguloDerecha < anguloPermitido || anguloIzquierda < anguloPermitido)
                    {
                        // Elimina el minienemigo
                        Destroy(minienemigo.gameObject);
                    }
                }
            }
        }
    }
}







