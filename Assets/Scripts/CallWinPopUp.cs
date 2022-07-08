using System;
using System.Collections.Generic;
using UnityEngine;

public class CallWinPopUp : MonoBehaviour
{
    public static Action win;
    private void OnCollisionEnter(Collision collision)
    {
        win?.Invoke();
    }
}
