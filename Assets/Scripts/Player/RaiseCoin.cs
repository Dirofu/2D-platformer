using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class RaiseCoin : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            _audio.Play();  
        }
    }
}
