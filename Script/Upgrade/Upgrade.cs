using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private const int maxLevel = 2;
    
    [Header("Text")]
    [SerializeField] Text pointText;
    [SerializeField] Text sizeLevelText;
    [SerializeField] Text speedLevelText;
    [SerializeField] Text defenseLevelText;
    [Header("Button")]
    [SerializeField] Button sizeLevelBtn;
    [SerializeField] Button speedLevelBtn;
    [SerializeField] Button defenseLevelBtn;
    [Header("Component")]
    [SerializeField] GameData gameData;
    [SerializeField] PlaySE playSE;


    void Start()
    {
        TextUpdate();
    }

    void Update()
    {
        TextUpdate();

        // ポイントが2つ以上なら強化できるようにする
        if (gameData.expPoint >= 2)
        {
            SizeLevelMax();
            SpeedLevelMax();
            DefenseLevelMax();
        }
        else
        {
            sizeLevelBtn.interactable = false;
            speedLevelBtn.interactable = false;
            defenseLevelBtn.interactable = false;
        }
    }

    // 表示しているテキストを更新
    private void TextUpdate()
    {
        pointText.text = gameData.expPoint.ToString("00");

        if (gameData.sizeLevel >= maxLevel)
        {
            sizeLevelText.text = "MAX.Lv";
        }
        else
        {
            sizeLevelText.text = gameData.sizeLevel + 1 + ".Lv";
        }

        if (gameData.speedLevel >= maxLevel)
        {
            speedLevelText.text = "MAX.Lv";
        }
        else
        {
            speedLevelText.text = gameData.speedLevel + 1 + ".Lv";
        }

        if (gameData.defenseLevel >= maxLevel)
        {
            defenseLevelText.text = "MAX.Lv";
        }
        else
        {
            defenseLevelText.text = gameData.defenseLevel + 1 + ".Lv";
        }
    }

    // 弾のサイズレベルが最大ならボタンを無効化
    private void SizeLevelMax()
    {
        if (gameData.sizeLevel >= maxLevel)
        {
            sizeLevelBtn.interactable = false;
        }
        else
        {
            sizeLevelBtn.interactable = true;
        }
    }

    // 弾速レベルが最大ならボタンを無効化
    private void SpeedLevelMax()
    {
        if (gameData.speedLevel >= maxLevel)
        {
            speedLevelBtn.interactable = false;
        }
        else
        {
            speedLevelBtn.interactable = true;
        }
    }

    // バリケードレベルが最大ならボタンを無効化
    private void DefenseLevelMax()
    {
        if (gameData.defenseLevel >= maxLevel)
        {
            defenseLevelBtn.interactable = false;
        }
        else
        {
            defenseLevelBtn.interactable = true;
        }
    }

    // 弾のサイズレベルを上げる 
    public void SizeUpgrade()
    {
        gameData.expPoint -= 2;
        gameData.sizeLevel += 1;
        PlayerPrefs.SetInt("POINT", gameData.expPoint);
        PlayerPrefs.SetInt("SIZE", gameData.sizeLevel);
        TextUpdate();
        gameData.SetStatusData();
        playSE.ButtonSE();
    }

    // 弾速レベルを上げる 
    public void SpeedUpgrade()
    {
        gameData.expPoint -= 2;
        gameData.speedLevel += 1;
        PlayerPrefs.SetInt("POINT", gameData.expPoint);
        PlayerPrefs.SetInt("SPEED", gameData.speedLevel);
        TextUpdate();
        gameData.SetStatusData();
        playSE.ButtonSE();
    }

    // バリケードレベルを上げる
    public void DefenseUpgrade()
    {
        gameData.expPoint -= 2;
        gameData.defenseLevel += 1;
        PlayerPrefs.SetInt("POINT", gameData.expPoint);
        PlayerPrefs.SetInt("DEFANSE", gameData.defenseLevel);
        TextUpdate();
        gameData.SetStatusData();
        playSE.ButtonSE();
    }
}
