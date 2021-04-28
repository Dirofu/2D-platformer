using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameObject _whatIsGround;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private bool _facingLeft;

    public bool Grounded { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            if (_facingLeft == false)
            {
                ExpandPlayer();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            if (_facingLeft == true)
            {
                ExpandPlayer();
            }
        }

        if (Grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce);
                Grounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _whatIsGround.layer)
        {
            Grounded = true;
        }
    }

    private void ExpandPlayer()
    {
        _facingLeft = !_facingLeft;
        Vector3 _scaler = transform.localScale;
        _scaler.x *= -1;
        transform.localScale = _scaler;
    }
}
