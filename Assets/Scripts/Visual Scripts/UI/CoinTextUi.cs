using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextUi : MonoBehaviour
{
    [SerializeField] private Text coinText;

    private CoinCollector _collector;

    private void Awake()
    {
        _collector = FindObjectOfType<CoinCollector>();
    }

    private void OnEnable()
    {
        _collector.OnCollect += HandleCoinCollected;
    }

    private void OnDisable()
    {
        _collector.OnCollect -= HandleCoinCollected;
    }

    private void HandleCoinCollected()
    {
        coinText.text = _collector.GetCollectedCount().ToString();
    }
}
