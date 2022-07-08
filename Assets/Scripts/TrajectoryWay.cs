using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryWay : MonoBehaviour
{
    [SerializeField] GameObject _tile;
    [SerializeField] Transform garbage;
    public void ShowTrajectory(Vector3 origin, Vector3 dir)
    {
        float time = 0.1f;

        var point = origin + dir * time;
        var dirY = dir.y / 4 * 100;

        if (Mathf.Abs(dirY) <= 5)
            dirY = 0;
        Instantiate(_tile, point, Quaternion.Euler(-dirY, 0, 0),garbage);

    }
    public void RemoveTileInGarbage()
    {
        for (int i = garbage.childCount - 1; i >= 0; i--)
        {
            Destroy(garbage.GetChild(i).gameObject);
        }
    }
}
