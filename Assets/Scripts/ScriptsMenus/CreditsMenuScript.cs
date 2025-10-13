using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsMenuScript : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
