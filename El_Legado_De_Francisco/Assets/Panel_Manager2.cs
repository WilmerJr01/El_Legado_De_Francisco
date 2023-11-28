using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class Panel_Manager2 : MonoBehaviour
{

    // Ruta del archivo JSON
    public TMP_InputField inputField;
    public string rutaArchivoJSON = "C:/Users/WILME/Desktop/El Legado De Francisco/El_Legado_De_Francisco/El_Legado_De_Francisco/Assets/Score.json";


    [System.Serializable]
    public class Fila
    {
        public string nombre;
        public int puntuacion;
    }

    [System.Serializable]
    public class ContenedorFilas
    {
        public List<Fila> filas;
    }

    void AgregarNuevoRegistro(string nombre, int puntuacion)
    {
        // Cargar registros existentes
        ContenedorFilas contenedor = CargarRegistros();

        // Crear un nuevo objeto Fila con los datos proporcionados
        Fila nuevaFila = new Fila
        {
            nombre = nombre,
            puntuacion = puntuacion
        };

        // Agregar la nueva fila al contenedor
        contenedor.filas.Add(nuevaFila);

        // Guardar el contenedor actualizado en el archivo JSON
        GuardarRegistros(contenedor);
    }

    void CargarYMostrarRegistros()
    {
        // Cargar registros existentes
        ContenedorFilas contenedor = CargarRegistros();

        // Mostrar los registros en la consola
        foreach (var fila in contenedor.filas)
        {
            Debug.Log($"Nombre: {fila.nombre}, Puntuación: {fila.puntuacion}");
        }
    }

    ContenedorFilas CargarRegistros()
    {
        // Verificar si el archivo JSON existe
        if (File.Exists(rutaArchivoJSON))
        {
            // Leer el contenido del archivo JSON
            string contenidoJSON = File.ReadAllText(rutaArchivoJSON);

            // Deserializar el contenido a un objeto ContenedorFilas
            ContenedorFilas contenedor = JsonUtility.FromJson<ContenedorFilas>(contenidoJSON);

            return contenedor;
        }
        else
        {
            // Si el archivo no existe, crear un nuevo contenedor
            return new ContenedorFilas { filas = new List<Fila>() };
        }
    }

    void GuardarRegistros(ContenedorFilas contenedor)
    {
        // Serializar el contenedor a formato JSON
        string jsonContenedor = JsonUtility.ToJson(contenedor);

        // Escribir el JSON en el archivo
        File.WriteAllText(rutaArchivoJSON, jsonContenedor);
    }
    public void play_button()
    {
        SceneManager.LoadScene(1);
    }
    public void scores_button() //Esto solo va a funcionar cuando descarguemos el juego, entonces mejor que tire algo por consola a ver si si funciona lol
    {
        
            // Ejemplo de cómo agregar un nuevo registro
            AgregarNuevoRegistro(inputField.text, int.Parse(ControladorPuntos.Instance.setPuntos()));

            // Luego, puedes cargar y mostrar los registros
            CargarYMostrarRegistros();

            SceneManager.LoadScene(5);
    }

}
