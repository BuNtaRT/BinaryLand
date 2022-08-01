using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationCollider : MonoBehaviour
{
    [SerializeField] private Heard _change;
    private Transform _curObj;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_curObj == null && col.CompareTag(Tags.PLAYER))
        {
            _change.ChangeProgress(1);
            _curObj = col.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_curObj == other.transform)
        {
            _change.ChangeProgress(-1);
            _curObj = null;
        }
    }
}
