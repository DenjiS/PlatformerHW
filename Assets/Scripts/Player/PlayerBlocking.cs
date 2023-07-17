using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class PlayerBlocking : MonoBehaviour
{
    private Animator _animator;

    public bool IsBlocking { get; private set; } = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            IsBlocking = true;
        }
        else
        {
            IsBlocking = false;
        }

        _animator.SetBool(AnimatorCommands.IsBlocking, IsBlocking);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsBlocking) { }
    }
}
