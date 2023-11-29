using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambio_escena : MonoBehaviour
{
    // Start is called before the first frame update
    public float tiempolimit;
    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= tiempolimit)
        {
            cambiar();
        }
        
    }

    void cambiar()
    {
        SceneManager.LoadScene(7);
    }
}
