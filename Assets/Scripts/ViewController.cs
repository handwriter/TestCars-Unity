using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ViewController : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private TMP_Text _tryTxt;
    [SerializeField] private string _tryTxtFormat;

    public Action OnStartBtnClick;

    private void Start()
    {
        _tryTxt.text = string.Format(_tryTxtFormat, ModelController.TryIndex + 1);
    }

    public void ShowWinScreen()
    {
        _winScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        _loseScreen.SetActive(true);
    }
    public void OnRestartBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }

    public void OnStartBtn()
    {
        OnStartBtnClick?.Invoke();
    }
}
