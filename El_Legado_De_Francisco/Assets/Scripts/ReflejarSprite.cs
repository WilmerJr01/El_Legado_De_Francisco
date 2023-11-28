using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReflejarSprite : MonoBehaviour
{
    // Referencia al componente SpriteRenderer del objeto
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtener la referencia al componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            // Asegurarse de que el objeto tenga un componente SpriteRenderer adjunto
            Debug.LogError("El objeto no tiene un componente SpriteRenderer.");
        }
        else
        {
            // Reflejar el sprite horizontalmente al iniciar el programa
            ReflejarSpriteHorizontalmente();
        }
    }

    // Método para reflejar el sprite horizontalmente
    private void ReflejarSpriteHorizontalmente()
    {
        // Obtener la escala actual del objeto
        Vector3 escala = transform.localScale;

        // Reflejar la escala horizontalmente multiplicando por -1 en el eje X
        escala.x *= -1;

        // Aplicar la nueva escala al objeto
        transform.localScale = escala;
    }
}
