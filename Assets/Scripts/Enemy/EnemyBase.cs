using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected List<TileBase> _whiteList;
    [SerializeField] protected Tilemap _map;
    protected Vector3 _position;
    protected TileMapService _mapService;

    private void Awake()
    {
        _position = transform.localPosition;
        _mapService = gameObject.AddComponent<TileMapService>();
        _mapService.Map = _map;
    }
}
