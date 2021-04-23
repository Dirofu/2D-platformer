using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _offset;

    private void Update()
    {
        transform.position = new Vector3(_player.position.x + _offset, transform.position.y, transform.position.z);
    }
}
