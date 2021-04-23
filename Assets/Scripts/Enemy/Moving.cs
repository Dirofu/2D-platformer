using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class Moving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxTimeWaiting;
    [SerializeField] private Transform _enemyPath;

    private SpriteRenderer _renderer;
    private Transform[] _points;
    private Animator _animator;
    private int _currentPoint;
    private float _timeWaiting;
    private bool _facingLeft;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _points = new Transform[_enemyPath.childCount];

        _animator.SetBool("isMoving", true);

        for (int i = 0; i < _enemyPath.childCount; i++)
        {
            _points[i] = _enemyPath.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position.x == target.position.x)
        {
            if (_timeWaiting <= 0)
            {
                _animator.SetBool("isMoving", true);
                _timeWaiting = _maxTimeWaiting;
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }
            else
            {
                _timeWaiting -= Time.deltaTime;
                _animator.SetBool("isMoving", false);
            }
        }

        if (transform.position.x > target.position.x && _facingLeft == true)
        {
            Flip();
        }
        else if (transform.position.x < target.position.x && _facingLeft == false)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
