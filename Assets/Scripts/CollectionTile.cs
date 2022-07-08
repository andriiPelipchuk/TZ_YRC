using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTile : MonoBehaviour
{
    [SerializeField] GameObject _tile;
    [SerializeField] Transform _backpack;

    private List<GameObject> _tilesInBackpack;

    private float _fixedDistanceBetweenTiles = 0.035f;
    private float _yPos = 0;

    private void Start()
    {
        _tilesInBackpack = new List<GameObject>();
    }
    public void RemoveArray()
    {
        for(int i = _backpack.childCount - 1; i >= 0; i--)
        {
            Destroy(_backpack.GetChild(i).gameObject);
        }
        _yPos = 0;
        if (_tilesInBackpack == null)
            return;
        _tilesInBackpack.RemoveAll(i=> _tilesInBackpack[0]);
    }

    public bool PutAwayTileFromArray()
    {
        if (_tilesInBackpack.Count <= 0)
        {
            return false;
        }
        Destroy(_tilesInBackpack[_tilesInBackpack.Count - 1]);
        _tilesInBackpack.Remove(_tilesInBackpack[_tilesInBackpack.Count - 1]);
        _yPos -= _fixedDistanceBetweenTiles;

        return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < 4; i++)
        {
            var newTile = Instantiate(_tile, new Vector3(_backpack.position.x, _backpack.position.y + _yPos, _backpack.position.z), Quaternion.identity, _backpack);
            _tilesInBackpack.Add(newTile);
            _yPos += _fixedDistanceBetweenTiles;
        }
    }
}
