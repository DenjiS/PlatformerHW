using UnityEngine;

public class PlayerDeath : MonoBehaviour, IDyeable
{
    [SerializeField] private HealthIcon[] _healthIcons;

    private Vector3 _initialPosition;
    private int _healthAmount;

    private void Start()
    {
        _initialPosition = transform.position;
        _healthAmount = _healthIcons.Length;
    }

    public void Die()
    {
        Destroy(_healthIcons[--_healthAmount].gameObject);

        if (_healthAmount > 0)
        {
            transform.position = _initialPosition;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
