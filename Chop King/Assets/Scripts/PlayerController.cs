using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveLeft, moveRight, attack;

    [Header("Positions")]
    [SerializeField] GameObject playerLeftPos;
    [SerializeField] GameObject playerRightPos;

    void Start()
    {

    }

    void Update()
    {
       
    }

    public void MoveLeft(InputAction.CallbackContext obj)
    {
        Debug.Log("MoveLeft");
        transform.position = playerLeftPos.transform.position;
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    public void MoveRight(InputAction.CallbackContext obj)
    {
        Debug.Log("MoveRight");
        transform.position = playerRightPos.transform.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void Attack(InputAction.CallbackContext obj)
    {

    }

    private void OnEnable()
    {
        moveLeft.action.performed += MoveLeft;

        moveRight.action.performed += MoveRight;

        attack.action.performed += Attack;
    }

    private void OnDisable()
    {
        moveLeft.action.performed -= MoveLeft;

        moveLeft.action.performed -= MoveRight;

        moveLeft.action.performed -= Attack;
    }
}
