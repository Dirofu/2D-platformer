using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform _groundCheck;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private bool _isGrounded;
    private bool _facingLeft;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, whatIsGround);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetBool("isMove", true);

            if (_facingLeft == false)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool("isMove", true);

            if (_facingLeft == true)
            {
                Flip();
            }
        }
        else
        {
            _animator.SetBool("isMove", false);
        }

        if (_isGrounded == true)
        {
            _animator.SetBool("isGrounded", true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce);
            }
        }
        else
        {
            _animator.SetBool("isGrounded", false);
        }
    }

    private void Flip()
    {
        _facingLeft = !_facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
