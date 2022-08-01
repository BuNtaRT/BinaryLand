using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private ValueStorage _storage;
    [SerializeField] private Text _message;
    [SerializeField] private Text _score;
    [SerializeField] private Text _time;

    public void ShowEndScreen(string message)
    {
        _message.text = message;
        _score.text = _storage.Score.ToString();
        _time.text = _storage.Time.ToString();
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
