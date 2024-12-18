using UnityEngine;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverScoreUI;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreUI;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            float finalScore = GameManager.Instance.currentScore;
            float highScore = GameManager.Instance.data.highscore;

            gameOverScoreUI.text = Mathf.RoundToInt(finalScore).ToString();
            gameOverHighScoreUI.text = Mathf.RoundToInt(highScore).ToString();
        }
        else
        {
            gameOverScoreUI.text = "0";
            gameOverHighScoreUI.text = "0";
        }
    }
}