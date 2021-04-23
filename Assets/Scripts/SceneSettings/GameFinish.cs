using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;

    private void Update()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        if (_coins.Length == 0)
        {
            Debug.Log("Game Over.");
        }
    }
}
