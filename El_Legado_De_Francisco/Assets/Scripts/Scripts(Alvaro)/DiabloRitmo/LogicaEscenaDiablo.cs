using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaEscenaDiablo : MonoBehaviour
{
    public float Errores = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Errores == 10)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flecha")
        {
            Errores += 1;
        }
    }
}
