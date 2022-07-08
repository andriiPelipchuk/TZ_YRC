using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTileOnThePlatform : MonoBehaviour
{
    [SerializeField] GameObject _heapTile;
    public float chance;

    private void Start()
    {
        SpawnTile();
    }
    public void SpawnTile()
    {
        for (int i = transform.childCount - 1; i >= 4; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = (int)transform.position.z - 4; i <= (int)transform.position.z + 4; i++)
        {
            for (float j = transform.position.x - 0.5f; j <= transform.position.x + 0.5; j+= 1)
            {
                var numberTile = Random.value > chance;
                if (numberTile)
                    continue;
                Instantiate(_heapTile, new Vector3(j, 0.5f, i), Quaternion.identity, gameObject.transform);
            }
        }
    }
}
