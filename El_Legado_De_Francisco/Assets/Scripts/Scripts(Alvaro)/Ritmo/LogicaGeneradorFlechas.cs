using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGeneradorFlechas : MonoBehaviour
{
    public GameObject[] flechas;
    private float TiempoEntreFlechas;
    public float TimeStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TiempoEntreFlechas <= 0)
        {
            int random = Random.Range(0, flechas.Length);
            Instantiate(flechas[random], transform.position, Quaternion.identity);

            TiempoEntreFlechas = TimeStart;
        }
        else
        {
            TiempoEntreFlechas -= Time.deltaTime;
        }
    }
}
