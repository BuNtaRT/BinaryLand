using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private enum Directions
    {
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
        Trap = 5,
    }

    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private bool _enable = true;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _playeNew = true;
    private Dictionary<Vector2Int, Directions> _animationDirections = new Dictionary<Vector2Int, Directions>();

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        _spriteRenderer.sprite = _defaultSprite;
        _animationDirections.Add(new Vector2Int(1, 0), Directions.Right);
        _animationDirections.Add(new Vector2Int(-1, 0), Directions.Left);
        _animationDirections.Add(new Vector2Int(0, 1), Directions.Up);
        _animationDirections.Add(new Vector2Int(0, -1), Directions.Down);
    }

    public void SetByVector(Vector2 direction)
    {
        
        if (_playeNew && _enable)
        {
            if (direction == Vector2.zero)
            {
                _animator.enabled = false;
                _spriteRenderer.sprite = _defaultSprite;
            }
            else
            {
                if (_animationDirections.TryGetValue(Vector2Int.RoundToInt(direction), out var directionEnum))
                {
                    _animator.enabled = true;
                    _animator.SetInteger("State", (int)directionEnum);
                    _spriteRenderer.flipX = directionEnum == Directions.Right;
                }
                else
                {
                    _animator.enabled = false;
                    _spriteRenderer.sprite = _defaultSprite;
                }
            }
        }
    }

    public void SetTrap(bool status)
    {
        Debug.Log(status);
        if (_enable)
        {
            _playeNew = !status;
            if (status)
            {
                _animator.enabled = true;
                _animator.SetInteger("State", (int)Directions.Trap);
            }
            else
            {
                _animator.enabled = false;
                _spriteRenderer.sprite = _defaultSprite;
            }
        }
    }
}