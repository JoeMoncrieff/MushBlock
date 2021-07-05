using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public GameManager gameManager;
    public static bool isInRestartMenu = false;
    public GameObject restartMenuUI;
    private GameObject scoreTracker;
    private void Awake()
    {
        scoreTracker = GameObject.Find("ScoreTracker");
    }
    public void triggerRestartMenu()
    {
        Time.timeScale = 0f;
        isInRestartMenu = true;
        restartMenuUI.SetActive(true);
        GameObject score = GameObject.Find("RestartScore");
        Text text = score.GetComponent<Text>();
        text.text = scoreTracker.GetComponent<ScoreTracker>().score.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameManager.RestartGame(0f);
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
