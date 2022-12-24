using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI multiplierText;

    [Header("Score")]
    public int pointsPerTree;
    public float multiplier;
    public float multiplierResetTime;

    private int score;
    private int treesDestroyed;

    private int multiplierNum;
    private bool isMultiplying;
    public float multiplierTimer;

    void Start()
    {
        isMultiplying = false;
    }

    void Update()
    {
        if (isMultiplying)
        {
            multiplierTimer -= Time.deltaTime;
            if(multiplierTimer <= 0)
            {
                multiplierNum = 0;
                isMultiplying = false;
                UpdateScoreText();
            }
        }
    }

    public void AddScore()
    {
        multiplierNum++;
        treesDestroyed++;

        float multiplierValue = multiplierNum * multiplier;
        score += (int)multiplierValue;
        multiplierTimer = multiplierResetTime;
        isMultiplying = true;

        score += pointsPerTree;

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;

        multiplierText.text = multiplierNum + "x";
    }
}
