using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class CompliteGameListener : MonoBehaviour
{
    [Serializable]
    private struct CompleteStrings
    {
        public FinishStatus Status;
        public string Message;
    }

    [SerializeField] private EndScreenUI _compliteScreen;
    [SerializeField] private List<CompleteStrings> FinishMessages = new List<CompleteStrings>();

    private void Awake()
    {
        GlobalEventManager.OnComplete.AddListener(OnComplete);
    }

    public void OnComplete(FinishStatus status)
    {
        string mes = FinishMessages.FirstOrDefault(x => x.Status == status).Message;
        _compliteScreen.gameObject.SetActive(true);
        _compliteScreen.ShowEndScreen(mes);
    }
}
