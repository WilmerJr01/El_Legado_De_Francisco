using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panel_manager : MonoBehaviour
{
    
    public void play_button()
    {
        SceneManager.LoadScene(1);
    }
    public void quit_button() //Esto solo va a funcionar cuando descarguemos el juego, entonces mejor que tire algo por consola a ver si si funciona lol
    {
        Application.Quit();
    }
    public void scores_button() //Esto solo va a funcionar cuando descarguemos el juego, entonces mejor que tire algo por consola a ver si si funciona lol
    {
        SceneManager.LoadScene(3);
    }
    public void back_button()
    {
        SceneManager.LoadScene(0);
    }

}
