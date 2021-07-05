using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreTracker : MonoBehaviour
{

    public TMP_Text scoreText;
    public GameObject restartMenu; 
    public int score;

    private void Awake()
    {
        restartMenu = GameObject.Find("RestartMenu");
    }
    public void ScoreUp()
    {
        score++;
        scoreText.text = "Score\n" + score.ToString();
    }
}
