using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class MovePlayer : MonoBehaviour
{
    public float Speed = 3.5f;
    private bool _enableInput = true;
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _delay = 1f;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.freezeRotation = true;
        _playerInput = GetComponent<PlayerInput>();
        GlobalEventManager.OnComplete.AddListener(OnGameEnd);
    }

    private void Start()
    {
        Invoke(nameof(EnableInput), _delay);
    }

    private void EnableInput() => _playerInput.enabled = true;

    public void OnGameEnd(FinishStatus status) => _enableInput = false;

    public void Enable(bool en) => _enableInput = en;

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>() * Speed;
    }

    private void FixedUpdate()
    {
        if (_enableInput)
            _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * Time.fixedDeltaTime);
    }
}
