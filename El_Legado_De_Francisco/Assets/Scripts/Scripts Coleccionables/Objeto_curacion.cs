using UnityEngine;

public class Objeto_curacion : MonoBehaviour
{
    public Combate_Jugador jugador;

    void Start()
    {
        // Puedes realizar configuraciones iniciales aquí si es necesario
    }

    void Update()
    {
        // Puedes agregar lógica de actualización aquí si es necesario
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes realizar acciones cuando el objeto de curación colisiona con el jugador
            Debug.Log("Objeto de curación tocó al jugador");
            GameObject objplayer = GameObject.FindGameObjectWithTag("Player");
            JugadorScript player = objplayer.GetComponent<JugadorScript>();
            player.CambiarColorJugador(Color.green);
            jugador.Curar(20);
            Destroy(gameObject);
        }
    }
}

