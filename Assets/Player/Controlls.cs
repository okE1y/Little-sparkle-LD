using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controlls : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Transform GetTransform;

    private WalkControll _walkControll;
    private JumpControll _jumpControll;

    public bool ControllsActive { get; set; } = true;

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (ControllsActive && (context.started || context.canceled || context.performed))
        {
            _walkControll.SetDirection(context.ReadValue<float>());
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (ControllsActive)
        {
            if (context.started) _jumpControll.ChangeJumpState(true);
            if (context.canceled) _jumpControll.ChangeJumpState(false);
        }
    }

    private void Start()
    {
        GetTransform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _walkControll = GetComponent<WalkControll>();
        _jumpControll = GetComponent<JumpControll>();
    }

}
