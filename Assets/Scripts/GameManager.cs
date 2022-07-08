using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _winPopUp;
    [SerializeField] GameObject _gameOverPopUp;
    public PlayerMove playerMove;
    private void Start()
    {
        CallGameOver.gameOver += CallPopUpGameOver;
        CallWinPopUp.win += WinPopUp;
        RestartLevel.restart += ClosePopUp;

        playerMove.AllowPlayerMovement();
    }
    private void CallPopUpGameOver()
    {
        StopPlayer();
        _gameOverPopUp.SetActive(true);
    }
    private void WinPopUp()
    {
        StopPlayer();
        _winPopUp.SetActive(true);
    }
    private void StopPlayer()
    {
        playerMove.StopPlayerMovement();
    }
    private void ClosePopUp()
    {
        _winPopUp.SetActive(false);
        _gameOverPopUp.SetActive(false);

        playerMove.AllowPlayerMovement();
    }
}
