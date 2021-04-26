using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    protected bool IsGrounded;
    private bool _facingLeft;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, whatIsGround);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            if (_facingLeft == false)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            if (_facingLeft == true)
            {
                Flip();
            }
        }

        if (IsGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce);
            }
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
