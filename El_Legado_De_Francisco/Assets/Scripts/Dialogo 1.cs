using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Dialogo1 : MonoBehaviour
{

    public TextMeshProUGUI TextDialogo;
    
    public string[] lineas;

    int index;

    public float textSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        TextDialogo.text = string.Empty;
        ComenzarDialogo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TextDialogo.text == lineas[index])
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                TextDialogo.text = lineas[index];
            }
        }
    }

    public void ComenzarDialogo() {

        index = 0;
        StartCoroutine(EscribirLinea());
    }


    IEnumerator EscribirLinea() {
        foreach (char letra in lineas[index].ToCharArray()) {
            TextDialogo.text += letra;

            yield return new WaitForSeconds(textSpeed);
        }
    } 

    public void SiguienteLinea() {
        if (index < lineas.Length - 1) {
            index++; 
            TextDialogo.text = string.Empty;
            StartCoroutine(EscribirLinea());
        } else {
            SceneManager.LoadScene(8);
            gameObject.SetActive(false);
        }
    }
}
