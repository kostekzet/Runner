using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject gameOverUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;

        if (gm != null)
        {
            gm.onGameOver.AddListener(ActivateGameOverUI);
            gm.StartGame();
        }
    }

    public void ActivateGameOverUI()
    {
        // Prze³¹cz UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // Prze³adowanie sceny Game Over
        SceneManager.LoadScene(2);
    }
    private IEnumerator LoadSceneWithDelay(int sceneIndex)
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneIndex);
    }

    private void OnGUI()
    {
        if (gm != null && scoreUI != null)
        {
            scoreUI.text = gm.PrettyScore();
        }
    }
}
