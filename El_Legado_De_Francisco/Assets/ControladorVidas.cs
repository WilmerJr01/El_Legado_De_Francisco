using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVidas : MonoBehaviour
{
    // Start is called before the first frame update
    public static ControladorVidas Instance;
    [SerializeField] public int cantidadVidas;

    private void Awake(){
        if(ControladorVidas.Instance ==null){
            ControladorVidas.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else{
            Destroy(gameObject);
        }
    }

    public void SumarVidas(int vida){

        cantidadVidas+=vida;
    }

    public string setVidas(){
        string puntosSalida=cantidadVidas.ToString("0");
        return puntosSalida;
    }
}
