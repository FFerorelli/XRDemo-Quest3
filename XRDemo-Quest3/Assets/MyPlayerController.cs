using StarterAssets;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyPlayerController : MonoBehaviour
{
    // assign the actions asset to this field in the inspector:
    public InputActionAsset actions;

    // private field to store move action reference
    private InputAction sprintAction;
    private InputAction jumpAction;
    public Vector2 moveVector;
    public bool jump;
    public bool sprint;



    void Awake()
    {
        // find the "move" action, and keep the reference to it, for use in Update
        actions.FindActionMap("Player").FindAction("Move").performed += OnMovePerformed;

        actions.FindActionMap("Player").FindAction("Move").canceled += OnMoveCanceled;


        // for the "jump" action, we add a callback method for when it is performed
        jumpAction = actions.FindActionMap("Player").FindAction("Jump");

        sprintAction = actions.FindActionMap("Player").FindAction("Sprint");
    }



    void Update()
    {
        JumpInput();
        SprintInput();
    }

    private void JumpInput()
    {
        if (jumpAction.triggered)
        {
            jump = true;
        }
    }
    private void SprintInput()
    {
        if (sprintAction.triggered)
        {
            sprint = !sprint;
            Debug.Log("Sprint!");
        }
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        Debug.Log("moving " + moveVector.x + " " + moveVector.y);
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
        sprint = false;
    }

    //public void JumpInput(bool newJumpState)
    //{
    //    jump = newJumpState;
    //}

    private void OnJump(InputAction.CallbackContext context)
    {
        // this is the "jump" action callback method
       // jump = context.ReadValue<bool>();
        Debug.Log("Jump!");
       // Debug.Log(jump);
    }
    private void OnSprint(InputAction.CallbackContext context)
    {
        Debug.Log("Sprint!");
    }

    void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }
    void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }
}