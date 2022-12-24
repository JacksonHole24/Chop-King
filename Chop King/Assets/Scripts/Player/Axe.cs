using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private GameManager gameManager;

    private bool canAttack;
    private GameObject currentTree;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (canAttack)
        {
            if (gameManager.playerController.isAttacking)
            {
                if(currentTree != null)
                {
                    if (currentTree.TryGetComponent<Tree>(out Tree tree))
                    {
                        tree.Die();
                        gameManager.playerController.isAttacking = false;
                    }
                    else Debug.LogError("Needs Tree Script");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            currentTree = other.gameObject;
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            currentTree = null;
            canAttack = false;
        }
    }
}
