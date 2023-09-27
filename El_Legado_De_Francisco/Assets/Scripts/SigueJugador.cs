using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigueJugador : MonoBehaviour
{
    public GameObject Jugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Jugador.transform.position;
    }
}
