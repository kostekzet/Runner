using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (SceneManager.GetActiveScene().name != "SampleScene")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
