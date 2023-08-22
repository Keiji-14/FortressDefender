using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// âÊñ ëJà⁄Çä«óù
/// </summary>
public class ChangeScene : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] PlaySE playSE;
    [SerializeField] GameProgression gameProgression;

    public void ChangeTitleScene()
    {
        gameProgression.gameStatus = GameStatus.Title;
        playSE.ButtonSE();
    }

    public void ChangeStageSelectScene()
    {
        gameProgression.gameStatus = GameStatus.StageSelect;
        playSE.ButtonSE();
    }

    public void ChangeGameScene()
    {
        gameProgression.gameStart = true;
        gameProgression.gameStatus = GameStatus.Game;
        playSE.ButtonSE();
    }

    public void ChangeGameOverScene()
    {
        gameProgression.gameStatus = GameStatus.GameOver;
    }

    public void ChangeGameClearScene()
    {
        gameProgression.gameStatus = GameStatus.GameClear;
    }

    public void ChangeUpGradeScene()
    {
        gameProgression.gameStatus = GameStatus.Upgrade;
        playSE.ButtonSE();
    }

    public void ChangeHelpScene()
    {
        gameProgression.gameStatus = GameStatus.Help;
        playSE.ButtonSE();
    }
}
