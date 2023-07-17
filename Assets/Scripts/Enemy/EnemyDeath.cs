using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDyeable
{
    [SerializeField] private Gem _loot;

    public void Die()
    {
        Instantiate(_loot, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
