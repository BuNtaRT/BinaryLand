using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Web : MonoBehaviour
{
    private MovePlayer _playerMove = null;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Tags.PLAYER) && _playerMove == null)
        {
            MovePlayer _player = col.GetComponent<MovePlayer>();
            _player.Enable(false);
            _player.transform.DOMove(transform.position, 1);
            _playerMove = _player;
            GlobalEventManager.CallTraps(1);
        }
    }

    private void OnDestroy()
    {
        GlobalEventManager.CallAddScore(200);
        if (_playerMove != null)
        {
            _playerMove.Enable(true);
            GlobalEventManager.CallTraps(-1);
        }
    }
}
