using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private LayerMask coinLayer;
    [SerializeField] private float collectRadius;
    [SerializeField] private float collectForce;

    private int _collectedCount;

    public event Action OnCollect;

    private void Update()
    {
        Collider2D coin = Physics2D.OverlapCircle(transform.position, collectRadius, coinLayer);
        if (coin && coin.TryGetComponent<Coin>(out var coinObject))
        {
            var direction = (transform.position - coinObject.transform.position).normalized;
            coinObject.GetRigidbody().velocity = direction * Mathf.InverseLerp(collectRadius, 0, Vector2.Distance(transform.position, coin.transform.position)) * collectForce;
        }
    }

    public void Collect()
    {
        _collectedCount++;
        OnCollect?.Invoke();
    }

    public int GetCollectedCount() => _collectedCount;
}