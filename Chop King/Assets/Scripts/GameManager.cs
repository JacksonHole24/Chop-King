using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public PlayerController playerController;
    [SerializeField] public Axe axe;
    [SerializeField] public ScoreManager scoreManager;

    void Awake()
    {
        RefreshScripts();
    }

    void Update()
    {
        
    }

    public void RefreshScripts()
    {
        playerController = FindObjectOfType<PlayerController>();
        axe = FindObjectOfType<Axe>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
}
