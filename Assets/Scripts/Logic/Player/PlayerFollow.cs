using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private float xOffset;

    private LevelData _levelData;

    private void Start()
    {
        _levelData = FindObjectOfType<LevelData>();

        if (!_levelData)
        {
            Debug.LogError("No level data on scene");
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_levelData.GetPlayerPosition().x + xOffset, transform.position.y, transform.position.z);
    }
}
