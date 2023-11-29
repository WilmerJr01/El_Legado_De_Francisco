using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Asegúrate de incluir este namespace para acceder a la clase Image

public class Inventario : MonoBehaviour
{
    public GameObject inv; // Debes declarar el GameObject que deseas activar/desactivar
    public bool activar_inv;
    public List<GameObject> Bag = new List<GameObject>();

    // Método para recoger objetos
    void OnTriggerEnter2D(Collider2D coll)
{
    if (coll.CompareTag("Coleccionable"))
    {
        for (int i = 0; i < Bag.Count; i++)
        {
            Image imageComponent = Bag[i].GetComponent<Image>();
            if (imageComponent != null && !imageComponent.enabled)
            {
                imageComponent.enabled = true;
                imageComponent.sprite = coll.GetComponent<SpriteRenderer>().sprite;

                // Desactivar el objeto Coleccionable del mapa
                coll.gameObject.SetActive(false);
                ControladorPuntos.Instance.SumarPuntos(5f);
                // Opcional: Destruir el objeto si no se va a utilizar más.
                // Destroy(coll.gameObject);

                break;
            }
        }
    }
}


    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que inv esté inicializado si es necesario
        if (inv == null)
        {
            Debug.LogError("El GameObject 'inv' no está asignado en el Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activar_inv)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            activar_inv = !activar_inv;
        }
    }
}

