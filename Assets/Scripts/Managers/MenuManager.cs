using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    private bool isOpen;

    public InputActionReference startAction;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        LockCursor();
    }

    void Update()
    {
        if (startAction.action.WasPressedThisFrame())
        {
            if (isOpen)
            {
                LockCursor();
            }
            else
            {
                UnlockCursor();
            }
            isOpen = !isOpen;
        }
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
