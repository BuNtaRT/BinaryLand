using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Enums;
using Runtime;
using UnityEngine;

public class SpiderAI : EnemyBase
{
    private bool _update = true;
    private TweenerCore<Vector3, Vector3, VectorOptions> _animation;
    private Coroutine _updateAI;

    private void Start()
    {
        GlobalEventManager.OnGameStart.AddListener(OnGameStart);
    }
    
    private void OnGameStart()
    {
        _updateAI = StartCoroutine(nameof(UpdateAI));
    }

    private IEnumerator UpdateAI()
    {
        Vector3 oldPos = _position;
        while (_update)
        {
            var emptyCells = _mapService.GetAroundEmptyWithFilter(_whiteList, _position);
            var newPos = emptyCells.GetRandom();
            _animation = transform.DOLocalMove(newPos, _speed).SetEase(Ease.Linear).OnComplete(() =>
            {
                oldPos = _position;
                _position = newPos;
            });
            yield return new WaitForSeconds(_speed);

            /*Решение без использования библиотеки DOTween*/
            /*
            Vector3 startPos = _position;
            float timeSteap = 0f;
            float speed = 1.5f;
            while (timeSteap < 1.0f)
            {
                timeSteap += Time.deltaTime * speed;
                gameObject.transform.position = Vector3.Lerp(startPos, newPos, timeSteap);
                yield return null;

            }
            _position = newPos;
            */

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Tags.PLAYER))
        {
            _update = false;
            GlobalEventManager.CallComplete(FinishStatus.Dead);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(_updateAI);
        _animation.Kill();
        _update = false;
        GlobalEventManager.CallAddScore(_scoreReward);
    }
}
