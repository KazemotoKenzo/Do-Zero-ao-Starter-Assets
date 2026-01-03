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
    public float jumpforce;
    public float gravityScale;

    private Vector3 playerVel;

    public Transform cam;

    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    [SerializeField]
    private CharacterController _controller;
    private bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        OnMove();
    }

    public void OnMove()
    {
        isGrounded = _controller.isGrounded;

        if (isGrounded)
        {
            if(playerVel.y < 2f) playerVel.y = -2f;
        }

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

        if(isGrounded && jumpAction.action.WasPressedThisFrame())   playerVel.y = Mathf.Sqrt(jumpforce * -2 * gravityScale);

        playerVel.y += gravityScale * Time.deltaTime;
        
        _controller.Move((move * move_speed + Vector3.up * playerVel.y) * Time.deltaTime);
    }
}
