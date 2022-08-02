using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(AnimationPlayer))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    public float Speed = 3.5f;
    private bool _enableInput = true;
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;
    private AnimationPlayer _animation;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.freezeRotation = true;
        _playerInput = GetComponent<PlayerInput>();
        _animation = GetComponent<AnimationPlayer>();
        GlobalEventManager.OnComplete.AddListener(OnGameEnd);
    }

    private void Start()
    {
        Invoke(nameof(EnableInput), _delay);
    }

    private void EnableInput()
    {
        GlobalEventManager.CallGameStart();
        _playerInput.enabled = true;
    }

    

    public void OnGameEnd(FinishStatus status) => _enableInput = false;

    public void TrapDisable(bool en)
    {
        _enableInput = en;
        _animation.SetTrap(!en);
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
        if (_movement.x != 0 && _movement.y != 0)
        {
            _movement.x = 0;
            _movement.y = Mathf.Round(_movement.y);
        }

        _animation.SetByVector(_movement);
        _movement *= Speed;
    }

    private void FixedUpdate()
    {
        if (_enableInput)
            _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * Time.fixedDeltaTime);
    }
}
