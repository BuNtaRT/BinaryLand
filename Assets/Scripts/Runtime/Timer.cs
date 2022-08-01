using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Runtime;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeLeft = 200;
    [SerializeField] private InGameUI _gameUI;
    private int _curentSteap = 0;
    private bool _isGameStop = false;
    
    private void Awake()
    {
        GlobalEventManager.OnComplete.AddListener(OnComplete);
    }

    private void OnComplete(FinishStatus arg0)
    {
        _isGameStop = true;
    }

    private void FixedUpdate()
    {
        if (!_isGameStop)
        {
            _timeLeft -= Time.deltaTime;
            _gameUI.ChangeTime((int)_timeLeft);
            if (_timeLeft < 0)
            {
                GlobalEventManager.CallComplete(FinishStatus.OutTime);
            }
        }
    }
}
