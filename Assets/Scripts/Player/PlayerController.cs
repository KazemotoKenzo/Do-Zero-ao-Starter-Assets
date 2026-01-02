using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float move_speed;
    [SerializeField]
    private float rotationSpeed;

    private Vector2 input_direction;
    private Vector3 moveDirection;
    
    public Transform cam;

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
        Vector3 move = cam.forward * input.y + cam.right * input.x;
        move.y = 0;
        move.Normalize();

        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation  = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        _controller.Move(move * move_speed * Time.deltaTime);
    }
}
