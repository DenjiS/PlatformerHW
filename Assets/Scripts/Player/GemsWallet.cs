using UnityEngine;
using UnityEngine.Events;

public class GemsWallet : MonoBehaviour
{
    private int _score = 0;

    public event UnityAction<int> OnChanged;

    private void Start()
    {
        OnChanged?.Invoke(_score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Gem gem))
        {
            OnChanged?.Invoke(++_score);
            Destroy(gem.gameObject);
        }
    }
}
