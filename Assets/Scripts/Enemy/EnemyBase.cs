using System;
using System.Collections;
using System.Collections.Generic;
using Runtime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 1;
    [SerializeField] protected List<TileBase> _whiteList;
    [SerializeField] protected Tilemap _map;
    [SerializeField]protected int _scoreReward = 0;
    protected Vector3 _position;
    protected TileMapService _mapService;
    protected Animator _animation;

    private void Awake()
    {
        _position = transform.localPosition;
        _mapService = gameObject.AddComponent<TileMapService>();
        _mapService.Map = _map;
        GlobalEventManager.OnUpSpeedGame.AddListener(OnGameUpSpeed);
        _animation = GetComponent<Animator>();
    }

    private void OnGameUpSpeed(float speed)
    {
        _animation.speed += speed;
        _speed = Mathf.Clamp((_speed - speed), 0.1f,1f);
    }
}
