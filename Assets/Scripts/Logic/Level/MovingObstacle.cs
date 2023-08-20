using Unity.VisualScripting;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float moveAmplitude;
    [SerializeField] private float timeForCycle;

    private Vector2 _startPosition;
    private bool _movingUp;

    private LevelData _levelData;

    private float _t;

    private void OnEnable()
    {
        _levelData = FindObjectOfType<LevelData>();

        _startPosition = transform.position;
        transform.position = new Vector3(_startPosition.x, _startPosition.y + Random.Range(-moveAmplitude, moveAmplitude));
        _t = Mathf.InverseLerp(_startPosition.y - moveAmplitude, _startPosition.y + moveAmplitude, transform.position.y);

        _movingUp = Random.Range(0f, 1f) >= 0.5f;
    }

    private void Update()
    {
        if (_levelData.GetPlayerPosition().x - transform.position.x > 50)
            Destroy(gameObject);

        if (_t >= 1)
        {
            _movingUp = !_movingUp;
            _t = 0;
        }

        var from = _movingUp ? _startPosition.y - moveAmplitude : _startPosition.y + moveAmplitude;
        var to = _movingUp ? _startPosition.y + moveAmplitude : _startPosition.y - moveAmplitude;
        _t += Time.deltaTime / timeForCycle;

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(from, to, EaseInOutSine(_t)));
    }

    private float EaseInOutSine(float x)
    {
        return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
    }
}