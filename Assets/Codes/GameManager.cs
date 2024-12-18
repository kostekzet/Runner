using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public float currentScore = 0f;

    public Data data;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    private void Start()
    {
        data = new Data();
        data.highscore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0;
    }

    public void GameOver()
    {
        onGameOver.Invoke();

        if (data.highscore < currentScore)
        {
            data.highscore = currentScore;
            PlayerPrefs.SetFloat("HighScore", data.highscore);
            PlayerPrefs.Save();
        }

        isPlaying = false;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
