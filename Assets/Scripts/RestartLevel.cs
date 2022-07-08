using System;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public static Action restart;
    [SerializeField] Transform _player;

    private Vector3 _startPlayerPos = new Vector3(0, 0.7f, -3);

    public void Restart()
    {
        var spawnTile = FindObjectsOfType<SpawnTileOnThePlatform>();
        for(int i = 0; i < spawnTile.Length; i++)
        {
            spawnTile[i].SpawnTile();
        }
        _player.position = _startPlayerPos;
        restart?.Invoke();
    }
}
