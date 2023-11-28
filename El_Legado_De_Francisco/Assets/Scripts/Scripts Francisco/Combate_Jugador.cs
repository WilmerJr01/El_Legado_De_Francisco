using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combate_Jugador : MonoBehaviour
{

    [SerializeField] private float vida;

    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;

    // Start is called before the first frame update
    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño){
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }

    }

    public void Curar(float curacion)
{
    if ((vida + curacion) > maximoVida)
    {
        vida = maximoVida;
    }
    else
    {
        vida += curacion;
    }

    // Agrega esta línea para actualizar la barra de vida
    barraDeVida.CambiarVidaActual(vida);
}

    // Update is called once per fram
}
