using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �|�[�Y��ʂ̏���
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameCanvas;

    // �|�[�Y�E�B���h�E��\������
    public void OpenPause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        gameCanvas.SetActive(false);
    }

    // �|�[�Y�E�B���h�E���\������
    public void ClosePause()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameCanvas.SetActive(true);
    }
}
