using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Min(0)][SerializeField] private float _speed;
    [SerializeField] private float _autoDestroyDelaySeconds;
    [SerializeField] private float _secondsBeforeActivation;

    private bool _isActivated = false;

    private void Awake()
    {
        PlayerDeath player = FindAnyObjectByType<PlayerDeath>();

        if (player.transform.position.x < transform.position.x)
            _speed *= -1;
    }

    private void Start()
    {
        StartCoroutine(DelayedActivation());
        Destroy(gameObject, _autoDestroyDelaySeconds);
    }

    private void Update()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBlocking block)
            && block.IsBlocking)
        {
            _speed *= -1;
            return;
        }

        if (collision.TryGetComponent(out IDyeable dyeable)
            && _isActivated == true)
        {
            dyeable.Die();
            Destroy(gameObject);
        }
    }

    private IEnumerator DelayedActivation()
    {
        yield return new WaitForSeconds(_secondsBeforeActivation);
        _isActivated = true;
    }
}
