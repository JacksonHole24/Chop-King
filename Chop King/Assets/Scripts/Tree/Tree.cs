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
        gameManager.treeSpawner.GetObjToSpawn();
        gameManager.scoreManager.AddScore();
        gameManager.Tree.GetComponent<BoxCollider2D>().offset = new Vector2(gameManager.Tree.GetComponent<BoxCollider2D>().offset.x, gameManager.Tree.GetComponent<BoxCollider2D>().offset.y + 200);
        gameManager.treeSpawner.treeParts.Remove(gameObject);
        Destroy(gameObject);
    }
}
