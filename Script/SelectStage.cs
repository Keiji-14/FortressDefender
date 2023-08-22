using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Easy,
    Normal,
    Hard,
    VeryHard,
    Extreme
}

public class SelectStage : MonoBehaviour
{
    [SerializeField] GameProgression gameProgression;

    public void SelectEasyLevel()
    {
        gameProgression.level = Level.Easy;
    }

    public void SelectNormalLevel()
    {
        gameProgression.level = Level.Normal;
    }

    public void SelectHardLevel()
    {
        gameProgression.level = Level.Hard;
    }

    public void SelectVeryHardLevel()
    {
        gameProgression.level = Level.VeryHard;
    }

    public void SelectExtremeLevel()
    {
        gameProgression.level = Level.Extreme;
    }
}
