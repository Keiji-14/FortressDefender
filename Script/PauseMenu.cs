using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポーズ画面の処理
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameCanvas;

    // ポーズウィンドウを表示する
    public void OpenPause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        gameCanvas.SetActive(false);
    }

    // ポーズウィンドウを非表示する
    public void ClosePause()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameCanvas.SetActive(true);
    }
}
