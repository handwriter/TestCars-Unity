using Ashsvp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ViewController View;
    public FinishController Finish;
    public PlayerController Player;
    public GhostCarController GhostCar;

    private void Start()
    {
        Finish.OnTrackFinished += FinishGame;
        Player.StopCar(false);
        View.OnStartBtnClick += StartGame;
    }

    public void StartGame()
    {
        Player.StartCar();
        if (ModelController.TryIndex > 0)
        {
            GhostCar.gameObject.SetActive(true);
            GhostCar.SetupPath(ModelController.LastCarPath);
        }
    }

    public void FinishGame(bool isWin)
    {
        ModelController.TryIndex += 1;
        if (isWin)
        {
            ModelController.LastCarPath = Player.GetActivePath();
            View.ShowWinScreen();
        }
        else
        {
            View.ShowLoseScreen();
        }
        Player.StopCar();
    }
}
