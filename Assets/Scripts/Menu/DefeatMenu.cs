using UnityEngine;
using UnityEngine.SceneManagement;


public class DefeatMenu : MonoBehaviour
{
    public void Exit()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainMenu");
    }
}
