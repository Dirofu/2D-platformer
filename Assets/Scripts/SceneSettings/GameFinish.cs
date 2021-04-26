using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;

    private int _collectedCoins;

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (var coin in _coins)
            coin.Picked += CoinPicked;
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
            coin.Picked -= CoinPicked;
    }

    private void Update()
    {
        if (_coins.Length == _collectedCoins)
        {
            Debug.Log("Game Over.");
        }
    }

    private void CoinPicked()
    {
        _collectedCoins++;
    }
}
