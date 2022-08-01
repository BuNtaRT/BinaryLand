using System.Collections;
using System.Collections.Generic;
using Enums;
using Runtime;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Heard : MonoBehaviour
{
    private int _colliderProgress = 0;
    [SerializeField] private Sprite _finalIco;

    public void ChangeProgress(int val)
    {
        _colliderProgress += val;
        if (_colliderProgress >= 2)
            CompleteLvl();

    }

    public void CompleteLvl()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _finalIco;
        GlobalEventManager.CallComplete(FinishStatus.Complete);
    }
}
