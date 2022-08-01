using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class WeaponDirection : MonoBehaviour
{
    [SerializeField] private GameObject _weaponObj;
    [SerializeField] private bool _isLeft;
    private Vector2 _helpVector = Vector2.left;

    private void Awake()
    {
        _helpVector = _isLeft ? Vector2.left : Vector2.right;
    }

    private void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        if (direction != Vector2.zero)
        {
            Vector2Int intV = new Vector2Int((int)direction.x, (int)direction.y);
            int sign = 0;
            if (_isLeft)
                sign = intV.y > 0 ? -1 : 1;
            else
                sign = intV.y > 0 ? 1 : -1;

            var angle = Vector2.Angle(_helpVector, intV) * sign;
            _weaponObj.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
