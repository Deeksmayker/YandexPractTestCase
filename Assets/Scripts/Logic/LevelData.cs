using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private Transform upLimit;
    [SerializeField] private Transform downLimit;

    [SerializeField] private Transform playerTransform;

    public Vector2 GetUpLimit() => upLimit.position;
    public Vector2 GetDownLimit() => downLimit.position;
    public Vector2 GetPlayerPosition() => playerTransform.position;
}

