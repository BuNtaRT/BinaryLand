using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Runtime;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class Timer : MonoBehaviour
{
    [Serializable]
    private struct UpSpeed
    {
        public int Progress;
        public float Factor;
    }
    [SerializeField] private List<UpSpeed> _progressUpSpeedGame = new List<UpSpeed>();
    [SerializeField] private float _timeLeft = 200;
    [SerializeField] private InGameUI _gameUI;
    private int _curentSteap = 0;
    private bool _isGameStop = false;
    private float _updateSpeed = 0.1f;
    
    private void Awake()
    {
        _gameUI.ChangeTime((int)_timeLeft);
        GlobalEventManager.OnComplete.AddListener(OnComplete);
        GlobalEventManager.OnGameStart.AddListener(OnGameStart);
    }

    private void OnGameStart()
    {
        StartCoroutine(nameof(UpdateTime));
    }
    
    private void OnComplete(FinishStatus arg0)
    {
        _isGameStop = true;
    }

    private IEnumerator UpdateTime()
    {
        while (_timeLeft > 0 && !_isGameStop)
        {

            _timeLeft -= 1;
            _gameUI.ChangeTime((int)_timeLeft);

            if (_progressUpSpeedGame.Count > 0 && _progressUpSpeedGame[0].Progress > _timeLeft)
            {
                GlobalEventManager.CallUpSpeedGame(_progressUpSpeedGame[0].Factor);
                _progressUpSpeedGame.RemoveAt(0);
            }

            yield return new WaitForSeconds(_updateSpeed);
        }

        if (!_isGameStop)
            GlobalEventManager.CallComplete(FinishStatus.OutTime);
    }
}
