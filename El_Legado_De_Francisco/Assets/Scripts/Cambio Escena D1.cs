using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambioEscenaD1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colision� tiene el tag "Square" (ajusta seg�n sea necesario)
        if (other.CompareTag("Cuadrado"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(2);
        }
    }

}
