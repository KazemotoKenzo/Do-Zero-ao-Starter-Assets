using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float move_speed;

    private Vector2 input_direction;
    private Vector3 moveDirection;

    public InputActionReference moveAction;

    [SerializeField]
    private CharacterController _controller;

    void Start()
    {
        
    }

    void Update()
    {
        OnMove();
    }

    public void OnMove()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        move = Vector3.ClampMagnitude(move, 1f);


        if (move != Vector3.zero)
            transform.forward = move;

        _controller.Move(move * move_speed * Time.deltaTime);

        //if (moveDirection.magnitude > Mathf.Epsilon)
        //{
        //    transform.rotation = Quaternion.LookRotation(moveDirection);
        //}
    }
}
