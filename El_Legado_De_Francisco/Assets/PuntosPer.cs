using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosPer : MonoBehaviour
{

    private static PuntosPer instancia;
    private float puntos;
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        if (instancia == null)
        {
            // Mantén este objeto entre escenas
            DontDestroyOnLoad(gameObject);
            instancia = this;
        }
        else
        {
            // Si ya existe una instancia, destruye este objeto
            Destroy(gameObject);
        }
    }

    private void Start()
{
    textMesh = GetComponent<TextMeshProUGUI>();
    if (textMesh == null)
    {
        Debug.LogError("El componente TextMeshProUGUI no está asignado en el Inspector.");
    }
}


    private void Update()
    {
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
