using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScript : MonoBehaviour
{
    public float distanciaAtaque = 1.5f;
    public LayerMask capaMinienemigo;

    void Update()
    {
        // Verifica si el jugador presiona la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Obtiene la dirección local hacia la derecha del objeto del jugador
            Vector2 direccionDerechaLocal = transform.right;

            // Calcula la posición del punto de ataque
            Vector2 puntoDeAtaque = (Vector2)transform.position + direccionDerechaLocal * distanciaAtaque;

            // Realiza un overlapCircle en el punto de ataque para detectar minienemigos
            Collider2D[] minienemigos = Physics2D.OverlapCircleAll(puntoDeAtaque, 0.1f, capaMinienemigo);

            // Itera sobre todos los minienemigos y elimínalos
            foreach (Collider2D minienemigoCollider in minienemigos)
            {
                MinienemigoScript minienemigo = minienemigoCollider.GetComponent<MinienemigoScript>();

                if (minienemigo != null)
                {
                    // Elimina el minienemigo
                    Destroy(minienemigo.gameObject);
                    Debug.Log("Minienemigo eliminado con éxito.");
                }
            }

            // Si no se encontraron minienemigos en la dirección hacia la derecha, intentamos hacia la izquierda
            if (minienemigos.Length == 0)
            {
                Vector2 direccionIzquierdaLocal = -transform.right;
                puntoDeAtaque = (Vector2)transform.position + direccionIzquierdaLocal * distanciaAtaque;

                minienemigos = Physics2D.OverlapCircleAll(puntoDeAtaque, 0.1f, capaMinienemigo);

                foreach (Collider2D minienemigoCollider in minienemigos)
                {
                    MinienemigoScript minienemigo = minienemigoCollider.GetComponent<MinienemigoScript>();

                    if (minienemigo != null)
                    {
                        Destroy(minienemigo.gameObject);
                        Debug.Log("Minienemigo eliminado con éxito.");
                    }
                }
            }
        }
    }
}


































