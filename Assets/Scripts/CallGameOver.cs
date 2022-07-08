using System;
using System.Collections.Generic;
using UnityEngine;

public class CallGameOver : MonoBehaviour
{
    public static Action gameOver;
    private void OnCollisionEnter(Collision collision)
    {
        gameOver?.Invoke();
    }
}
