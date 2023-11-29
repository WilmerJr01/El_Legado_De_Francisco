using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaArribaD : MonoBehaviour
{
    public float velocidad;
    public int contador = 0;
    public bool adentro = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * -velocidad * Time.deltaTime;
        if (contador == 2)
        {
            adentro = true;
        }
        else
        {
            adentro = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (adentro == true)
            {
                GameObject.Find("CasillaJugadorD").GetComponent<JugadorDiablo>().puntaje++;
                GameObject.Find("CasillaJugadorD").GetComponent<JugadorDiablo>().texto.text = "Puntaje: " +
                    GameObject.Find("CasillaJugadorD").GetComponent<JugadorDiablo>().puntaje.ToString();
                Destroy(gameObject);
            }
        }


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contador++;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contador--;
        }
    }
}
