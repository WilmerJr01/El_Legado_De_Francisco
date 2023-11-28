using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosGameOver : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = ControladorPuntos.Instance.setPuntos();
    }
}
