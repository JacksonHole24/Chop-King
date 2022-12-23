using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Positions")]
    public Vector2 playerLeftPos;
    public Vector2 playerRightPos;

    private void Awake()
    {
        
    }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        
    }
}
