using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;
using System;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] float _movementSpeed = 5f;
    [SerializeField] Animator _animator;

    CharacterController _characterController;

    int _isRunningHash;
    Vector3 _previousInput;
    bool _isMovementPressed = false;

    Controls _controls;
    public Controls Controls
    {
        get
        {
            if (_controls != null) { return _controls; }
            return _controls = new Controls();
        }
    }

    public override void OnStartAuthority()
    {
        enabled = true;

        _characterController = GetComponent<CharacterController>();
        _isRunningHash = Animator.StringToHash("isRunning");

        Controls.PlayerControls.Movement.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.PlayerControls.Movement.canceled += ctx => ResetMovement();
    }

    [ClientCallback]
    private void OnEnable() => Controls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.Disable();

    [Client]
    private void Update()
    {
        if (!hasAuthority)
            return;
        Move();
    }

    private void SetMovement(Vector2 movement)
    {
        _previousInput = new Vector3(movement.x, 0f, movement.y);
        _isMovementPressed = true;
    }

    private void ResetMovement()
    {
        _previousInput = Vector2.zero;
        _isMovementPressed = false;
    }

    private void Move()
    {
        _characterController.Move(_previousInput * _movementSpeed * Time.deltaTime);
        if (_isMovementPressed)
        {
            HandleRotation();
        }

        HandleAnimation();
    }

    private void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _previousInput.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = _previousInput.z;

        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);

        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 15f * Time.deltaTime); // change '15f' to adjust how quickly the player rotates
        _animator.gameObject.transform.rotation = transform.rotation;
    }

    private void HandleAnimation()
    {
        // more complicated move animations could go here, but this is all we need for now
        _animator.SetBool(_isRunningHash, _isMovementPressed);
    }
}
