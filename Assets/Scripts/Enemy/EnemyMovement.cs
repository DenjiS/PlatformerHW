using DG.Tweening;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _flipSpeed;

    private Tween _moveTween;
    private Vector3[] _movePoints;

    private void Awake()
    {
        _movePoints = GetComponentsInChildren<MovePoint>()
            .Select(component => component.transform.position)
            .ToArray();
    }

    private void Start()
    {
        _moveTween = transform.DOPath(_movePoints, _moveSpeed, PathType.Linear, PathMode.Sidescroller2D).SetSpeedBased()
            .SetLookAt(_flipSpeed).SetOptions(true)
            .SetLoops(-1).SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        _moveTween.Kill();
    }
}
