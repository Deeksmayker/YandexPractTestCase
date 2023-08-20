using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D _rb;

    private LevelData _levelData;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _levelData = FindObjectOfType<LevelData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CoinCollector>(out var collector))
        {
            collector.Collect();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_levelData.GetPlayerPosition().x - transform.position.x > 50)
            Destroy(gameObject);
    }

    public Rigidbody2D GetRigidbody() => _rb;
}