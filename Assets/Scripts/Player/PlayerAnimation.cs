using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            _animator.SetBool("isMove", true);
        else
            _animator.SetBool("isMove", false);

        if (_player.Grounded == false)
            _animator.SetBool("isGrounded", false);
        else
            _animator.SetBool("isGrounded", true);
    }
}
