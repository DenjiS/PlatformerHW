using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerBlocking))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundedDistance;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private PlayerBlocking _blocking;
    private Vector3 _rightDirectionScale;
    private Vector3 _leftDirectionScale;
    private Vector3 _jumpVector;

    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _blocking = GetComponent<PlayerBlocking>();

        _rightDirectionScale = transform.localScale;
        _leftDirectionScale = new Vector3(_rightDirectionScale.x * -1, _rightDirectionScale.y, _rightDirectionScale.z);
        _jumpVector = new Vector3(0, _jumpForce, 0);

        _isGrounded = true;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        _isGrounded = CheckGrounded();
        _animator.SetBool(AnimatorCommands.IsGrounded, _isGrounded);
    }

    private void Move()
    {
        float horizontaldirection = Input.GetAxis("Horizontal");

        if (horizontaldirection != 0 &&
            _blocking.IsBlocking == false)
        {
            if (horizontaldirection > 0)
                transform.localScale = _rightDirectionScale;
            else if (horizontaldirection < 0)
                transform.localScale = _leftDirectionScale;

            transform.Translate(new Vector3(horizontaldirection * _moveSpeed * Time.deltaTime, 0, 0));
            _animator.SetBool(AnimatorCommands.IsRunning, true);
        }
        else
        {
            _animator.SetBool(AnimatorCommands.IsRunning, false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) &&
            _isGrounded)
        {
            _rigidbody.AddForce(_jumpVector, ForceMode2D.Impulse);
        }
    }

    private bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundedDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
