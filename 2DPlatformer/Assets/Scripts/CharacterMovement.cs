using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private CharState State
    {
        get { return (CharState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Transform _groundCheck;
    private const string GroundCheck = "GroundCheck";

    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _groundCheck = transform.Find(GroundCheck);
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if(_isGrounded)
            State = CharState.Idle;

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
        _spriteRenderer.flipX = direction.x < 0.0f;

        if (_isGrounded) 
            State = CharState.Run;
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);

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
