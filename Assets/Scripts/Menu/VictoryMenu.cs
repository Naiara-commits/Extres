using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryMenu : MonoBehaviour
{
   public void Exit()
   {
        SceneManager.LoadScene("MainMenu");
   }
}
