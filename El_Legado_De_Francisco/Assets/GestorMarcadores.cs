using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class Row
{
    public string nombre;
    public int puntuacion;
}

[System.Serializable]
public class ContenedorFilas
{
    public Row[] filas;
}

public class GestorMarcadores : MonoBehaviour
{
     
    public  TextMeshProUGUI marcadoresTextNombre; // Asigna un objeto Text en el Inspector.
    public  TextMeshProUGUI marcadoresTextPuntos; // Asigna un objeto Text en el Inspector.

    void Start()
    {
        try
        {
            string contenidoJSON = System.IO.File.ReadAllText(Path.GetFullPath("Assets/Score.json"));

            // Deserializa el JSON usando JsonUtility
            ContenedorFilas contenedor = new ContenedorFilas();
            contenedor = JsonUtility.FromJson<ContenedorFilas>(contenidoJSON);

            if (contenedor != null && contenedor.filas != null)
            {
                // Ordena las filas por puntaje de mayor a menor
                contenedor.filas = contenedor.filas.OrderByDescending(f => f.puntuacion).ToArray();

                // Ahora puedes mostrar los marcadores en un objeto de texto
                foreach (var fila in contenedor.filas)
                {
                    marcadoresTextNombre.text += $"{fila.nombre}\n";
                    marcadoresTextPuntos.text += $"{fila.puntuacion}\n";

                }
            }
            else
            {
                Debug.LogError("ContenedorFilas o filas es nulo.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error al deserializar el JSON: {e.Message}");
        }
    }
}
