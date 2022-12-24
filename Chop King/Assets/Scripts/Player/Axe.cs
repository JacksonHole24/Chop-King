using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axe : MonoBehaviour
{
    public float attackTime;

    private GameManager gameManager;

    private bool canAttack;
    private GameObject currentTree;

    private bool cannotAttack = false;
    private float cannotAttackTimer;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        cannotAttackTimer = attackTime;
    }

    private void Update()
    {
        if (!cannotAttack)
        {
            if (canAttack)
            {
                if (gameManager.playerController.isAttacking)
                {
                    if (currentTree != null)
                    {
                        if (currentTree.TryGetComponent<Tree>(out Tree tree))
                        {
                            tree.Die();
                            gameManager.playerController.isAttacking = false;
                            cannotAttack = true;
                        }
                        else Debug.LogError("Needs Tree Script");
                    }
                }
            }
        }
        else
        {
            GetComponent<RawImage>().enabled = false;
            cannotAttackTimer -= Time.deltaTime;
            if(cannotAttackTimer <= 0)
            {
                cannotAttackTimer = attackTime;
                cannotAttack = false;
                GetComponent<RawImage>().enabled = true;
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
