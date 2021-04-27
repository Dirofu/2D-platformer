using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMovement))]

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _enemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (_enemy.IsWorth)
            _animator.SetBool("isMoving", true);
        else
            _animator.SetBool("isMoving", false);
    }
}
