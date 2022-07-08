using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] TrajectoryWay _trajectoryRenderer;
    [SerializeField] CollectionTile _colectionTile;
    [SerializeField] GameObject _tile;
    [SerializeField] Rigidbody _rb;

    private float fixedTime = 0.1f;
    private float _startMousePosYOnScreen;
    private int _iterator = 0;
    private int _speed;
    private bool _canMove;
    private float _elapsed = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MoveHorizontal();
    }
    public void AllowPlayerMovement()
    {
        _speed = 5;
        _canMove = true;
        _rb.isKinematic = false;
        _colectionTile.RemoveArray();
        _trajectoryRenderer.RemoveTileInGarbage();
    }
    public void StopPlayerMovement()
    {
        _speed = 0;
        _canMove = false;
        _rb.isKinematic = true;
        _colectionTile.RemoveArray();
        _trajectoryRenderer.RemoveTileInGarbage();
    }
    private void MoveHorizontal()
    {
        transform.position = transform.position + Vector3.forward * _speed * Time.fixedDeltaTime;
        MoveMouseUpOrLower();
    }
    private void MoveMouseUpOrLower()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _iterator = 0;
        }
        if (Input.GetMouseButton(0) && _canMove)
        {
            for (; _iterator < 1; _iterator++)
            {
                _startMousePosYOnScreen = Input.mousePosition.y;
            }
            var newMousePosY = Input.mousePosition.y - _startMousePosYOnScreen;
            DetermineDirection(newMousePosY);
        }
    }

    private void DetermineDirection(float newMousePosY)
    {
        var trajector = new Vector3(transform.position.x, newMousePosY, transform.position.z);

        _elapsed += Time.deltaTime;
        if(_elapsed >= fixedTime)
        {
            _elapsed = _elapsed % fixedTime;
            if (!_colectionTile.PutAwayTileFromArray())
                return;
            _trajectoryRenderer.ShowTrajectory(transform.GetChild(1).position, trajector.normalized);
        }
        

        if (newMousePosY < -20)
        {
            MoveVertical(-1);
        }
        else if(newMousePosY > 20)
        {
            MoveVertical(1);
        }

    }

    private void MoveVertical(float y)
    {
        transform.position = transform.position + new Vector3(0, y, 0) * 3 * Time.fixedDeltaTime;
    }
}