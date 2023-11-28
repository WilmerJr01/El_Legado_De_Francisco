using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntajeJugador : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update(){
        textMesh.text = ControladorPuntos.Instance.setPuntos();
    }

}
