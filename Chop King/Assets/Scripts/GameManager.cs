using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject Tree;
    [SerializeField] public PlayerController playerController;
    [SerializeField] public Axe axe;
    [SerializeField] public ScoreManager scoreManager;
    [SerializeField] public TreeSpawner treeSpawner;

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
        treeSpawner = FindObjectOfType<TreeSpawner>();
    }
}
