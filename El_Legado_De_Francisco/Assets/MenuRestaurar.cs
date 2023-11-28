using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuRestaurar : MonoBehaviour
{
    public TextMeshProUGUI inputField1;
    public TextMeshProUGUI inputField2;

    // Update is called once per frame
    void Update()
    {
        inputField1.text = ControladorVidas.Instance.setVidas();
        Debug.Log(inputField1);
        inputField2.text = ControladorPuntos.Instance.setPuntos();
    }
}
