using UnityEngine;

public class OnHitKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerDeath player))
            player.Die();
    }
}
