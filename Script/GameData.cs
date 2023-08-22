using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int expPoint;
    [Header("Level")]
    public int sizeLevel;
    public int speedLevel;
    public int defenseLevel;
    [Header("Status")]
    public float sizeStatus;
    public float speedStatus;
    public float defenseStatus;

    void Start()
    {
        SetGameData();
        SetStatusData();
    }

    // ゲーム開始時にそれぞれのレベルを読み込む
    public void SetGameData()
    {
        expPoint = PlayerPrefs.GetInt("POINT", 0);
        sizeLevel = PlayerPrefs.GetInt("SIZE", 0);
        speedLevel = PlayerPrefs.GetInt("SPEED", 0);
        defenseLevel = PlayerPrefs.GetInt("DEFANSE", 0);
    }

    // 各レベルからステータスを設定
    public void SetStatusData()
    {
        switch (sizeLevel)
        {
            case 0:
                sizeStatus = 1;
                break;
            case 1:
                sizeStatus = 1.25f;
                break;
            case 2:
                sizeStatus = 1.5f;
                break;
        }

        switch (speedLevel)
        {
            case 0:
                speedStatus = 3000;
                break;
            case 1:
                speedStatus = 4000;
                break;
            case 2:
                speedStatus = 5000;
                break;
        }

        switch (defenseLevel)
        {
            case 0:
                defenseStatus = 1;
                break;
            case 1:
                defenseStatus = 2;
                break;
            case 2:
                defenseStatus = 3;
                break;
        }
    }

    public void PointMax()
    {
        if (expPoint > 99)
        {
            expPoint = 99;
        }
    }
}
