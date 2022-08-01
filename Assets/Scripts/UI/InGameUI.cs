using System;
using System.Collections;
using System.Collections.Generic;
using Runtime;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private ValueStorage _storage;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _timeText;

    private void Awake()
    {
        GlobalEventManager.OnScore.AddListener(OnScore);
    }

    public void ChangeTime(int time)
    {
        _storage.Time = time;
        _timeText.text = time.ToString();
    }

    private void OnScore(int score)
    {
        _storage.Score += score;
        _scoreText.text = _storage.Score.ToString();
    }
}
