using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;
    [SerializeField] public float cantidadPuntos;

    private void Awake(){
        if(ControladorPuntos.Instance ==null){
            ControladorPuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else{
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(float puntos){

        cantidadPuntos +=puntos;
    }

    public string setPuntos(){
        string puntosSalida=cantidadPuntos.ToString("0");
        return puntosSalida;
    }
}
