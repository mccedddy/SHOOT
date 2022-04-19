using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    public TextMeshProUGUI text_score;
    public TextMeshProUGUI text_highscore;

    private float timer;
    public static int score;

    void Update()
    {
        if (GameControl.playing == true)
        {
            // +1 Score/s
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                score += 1;
                text_score.text = "Score: " + score.ToString();
                timer = 0;
            }
        }
        
        // 1st High Score
        if (PlayerPrefs.HasKey("highscore") == false)
        {
            PlayerPrefs.SetInt("highscore", 0);
        }

        // New High Score
        else
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }

        // Display High Score
        text_highscore.text = "High Score: " + PlayerPrefs.GetInt("highscore");
    }
}
