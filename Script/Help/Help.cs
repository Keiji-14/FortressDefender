using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum HelpWindow
{
    Select,
    Game,
    Play,
    Level,
    Point,
    Upgrade
}

public class Help : MonoBehaviour
{
    [Header("HelpWindow")]
    [SerializeField] GameObject selectHelp;
    [SerializeField] GameObject gameHelp;
    [SerializeField] GameObject playHelp;
    [SerializeField] GameObject levelHelp;
    [SerializeField] GameObject pointHelp;
    [SerializeField] GameObject upgradeHelp;

    [Header("BackButton")]
    [SerializeField] GameObject titleBackButton;
    [SerializeField] GameObject selectBackButton;

    [Header("Component")]
    [SerializeField] PlaySE playSE;
    [SerializeField] GameProgression gameProgression;

    HelpWindow helpWindow;

    void Update()
    {
        switch (helpWindow)
        {
            case HelpWindow.Select:
                selectHelp.SetActive(true);
                gameHelp.SetActive(false);
                playHelp.SetActive(false);
                levelHelp.SetActive(false);
                pointHelp.SetActive(false);
                upgradeHelp.SetActive(false);
                titleBackButton.SetActive(true);
                selectBackButton.SetActive(false);
                break;
            case HelpWindow.Game:
                selectHelp.SetActive(false);
                gameHelp.SetActive(true);
                titleBackButton.SetActive(false);
                selectBackButton.SetActive(true);
                break;
            case HelpWindow.Play:
                selectHelp.SetActive(false);
                playHelp.SetActive(true);
                titleBackButton.SetActive(false);
                selectBackButton.SetActive(true);
                break;
            case HelpWindow.Level:
                selectHelp.SetActive(false);
                levelHelp.SetActive(true);
                titleBackButton.SetActive(false);
                selectBackButton.SetActive(true);
                break;
            case HelpWindow.Point:
                selectHelp.SetActive(false);
                pointHelp.SetActive(true);
                titleBackButton.SetActive(false);
                selectBackButton.SetActive(true);
                break;
            case HelpWindow.Upgrade:
                selectHelp.SetActive(false);
                upgradeHelp.SetActive(true);
                titleBackButton.SetActive(false);
                selectBackButton.SetActive(true);
                break;
        }
    }

    public void ChangeSelectHelp()
    {
        helpWindow = HelpWindow.Select;
        playSE.ButtonSE();
    }

    public void ChangeGameHelp()
    {
        helpWindow = HelpWindow.Game;
        playSE.ButtonSE();
    }

    public void ChangePlayHelp()
    {
        helpWindow = HelpWindow.Play;
        playSE.ButtonSE();
    }

    public void ChangeLevelScene()
    {
        helpWindow = HelpWindow.Level;
        playSE.ButtonSE();
    }

    public void ChangePointScene()
    {
        helpWindow = HelpWindow.Point;
        playSE.ButtonSE();
    }

    public void ChangeUpgradeScene()
    {
        helpWindow = HelpWindow.Upgrade;
        playSE.ButtonSE();
    }
}
