using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFolowPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _player.position.y + 1.65f, _player.position.z - 6.5f);
    }
}
