using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class LogicaJugador : MonoBehaviour
{
    public int puntaje = 0;
    public TextMeshProUGUI texto;
    public bool adentro = false;
    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puntaje == 15)
        {
            SceneManager.LoadScene("Escena #2");
        }
    }
}
