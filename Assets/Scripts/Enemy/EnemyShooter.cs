using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Bullet _template;
    [SerializeField] private float _shootWaitSeconds;
    [SerializeField] private float _spotDistance;

    private Rigidbody2D _rigidbody;
    private WaitForSeconds _shotAwait;

    private Coroutine _shotCoroutine = null;

    private void Awake()
    {
        _shotAwait = new WaitForSeconds(_shootWaitSeconds);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        List<RaycastHit2D> spotHits = new();

        _rigidbody.Cast(Vector2.left, spotHits, _spotDistance);
        SpotPlayer(spotHits);
        _rigidbody.Cast(Vector2.right, spotHits, _spotDistance);
        SpotPlayer(spotHits);
    }

    private void SpotPlayer(List<RaycastHit2D> spotHits)
    {
        if (spotHits.Any(hit => hit.collider.transform.TryGetComponent(out PlayerDeath player)))
        {
            if (_shotCoroutine == null)
                _shotCoroutine = StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        Instantiate(_template, transform.position, Quaternion.identity);
        yield return _shotAwait;
        _shotCoroutine = null;
    }
}
