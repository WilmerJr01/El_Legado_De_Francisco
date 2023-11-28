using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
    
{
    public Combate_Jugador jugador1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes realizar acciones cuando el proyectil colisiona con el jugador
            Debug.Log("Proyectil tocó al jugador");
            jugador1.TomarDaño(5);

            // Puedes agregar lógica adicional, como infligir daño al jugador o destruir el proyectil
            Destroy(gameObject);
        }
    }
}
