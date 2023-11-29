using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        // Obtener o agregar el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Asignar el AudioClip y configurar para reproducir en bucle
            audioSource.clip = clip;
            audioSource.loop = true;

            // Reproducir el audio desde el inicio
            audioSource.Play();
        }
    }
}
