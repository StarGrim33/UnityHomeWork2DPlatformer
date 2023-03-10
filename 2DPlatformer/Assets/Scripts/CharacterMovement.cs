using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(Transform))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private static readonly int StateHash = Animator.StringToHash("State");

    public CharState State
    {
        get { return (CharState)_animator.GetInteger(StateHash); }
        private set { _animator.SetInteger(StateHash, (int)value); }
    }

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _groundCheckTransform = GetComponentInChildren<Transform>();
    }

    private void FixedUpdate()
    {
        UpdateIsGrounded();
    }

    private void Update()
    {
        if(_isGrounded)
            State = CharState.Idle;

        if (Input.GetButton("Horizontal"))
            Run();

        if (_isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        float spriteDirection = 0.0f;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
        _spriteRenderer.flipX = direction.x < spriteDirection;

        if (_isGrounded) 
            State = CharState.Run;
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void UpdateIsGrounded()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRadius, _whatIsGround);

        if (!_isGrounded)
            State = CharState.Jump;
    }
}

public enum CharState
{
    Idle,
    Run,
    Jump
}
