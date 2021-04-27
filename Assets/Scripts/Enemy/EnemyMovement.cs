using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxTimeWaiting;
    [SerializeField] private Transform _enemyPath;

    private SpriteRenderer _renderer;
    private Transform[] _points;
    private int _currentPoint;
    private bool _facingRight;
    private float _timeWaiting;

    public bool IsWorth { get; private set; }

    private void Start()
    {
        _points = new Transform[_enemyPath.childCount];
        IsWorth = true;

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
                IsWorth = true;
                _timeWaiting = _maxTimeWaiting;
                _currentPoint++;

                if (_currentPoint == _points.Length)
                {
                    _currentPoint = 0;
                }
            }
            else
            {
                IsWorth = false;
                _timeWaiting -= Time.deltaTime;
            }
        }

        if (transform.position.x > target.position.x && _facingRight == true)
        {
            ExpandEnemy();
        }
        else if (transform.position.x < target.position.x && _facingRight == false)
        {
            ExpandEnemy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ExpandEnemy()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
