using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorDiablo : MonoBehaviour
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
        if (puntaje == 40)
        {
            SceneManager.LoadScene(10);
        }
    }
}
