using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Animation : Movement
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            _animator.SetBool("isMove", true);
        else
            _animator.SetBool("isMove", false);

        if (Input.GetKey(KeyCode.Space) && IsGrounded == false)
            _animator.SetBool("isGrounded", false);
        else
            _animator.SetBool("isGrounded", true);
            

    }
}
