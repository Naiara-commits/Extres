using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ 
    public void Resumir()
    {
        SceneManager.UnloadSceneAsync("PauseMenu"); // Desactiva el menu pausa
        Time.timeScale = 1f; // Vuelve a activar el tiempo
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
