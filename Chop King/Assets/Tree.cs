using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Die()
    {
        gameManager.scoreManager.AddScore();
        Destroy(gameObject);
    }
}
