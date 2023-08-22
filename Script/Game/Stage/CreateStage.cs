using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 敵の生成などのゲーム処理
/// </summary>
public class CreateStage : MonoBehaviour
{
    // ステージクリアのポイント
    private const int clearPoint = 1;
    // 画面外の開始位置の調整用
    private const float correctionPosY = 6;

    public bool resetBullet;
    public bool resetBarricade;
    private bool clear;

    [Header("GameStageData")]
    [SerializeField] StageData stageData;
    [Header("LevelStageData")]
    [SerializeField] StageData easyStageData;
    [SerializeField] StageData normalStageData;
    [SerializeField] StageData hardStageData;
    [SerializeField] StageData veryHardStageData;
    [SerializeField] StageData extremeStageData;
    [Header("GameObject")]
    [SerializeField] GameObject barricadeObject;
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject cannonOblect;
    [Header("Transform")]
    [SerializeField] Transform enemyParent;
    [Header("Text")]
    [SerializeField] Text enemyCountText;
    [Header("Component")]
    [SerializeField] GameData gameData;
    [SerializeField] ChangeScene changeScene;
    [SerializeField] GameProgression gameProgression;

    void Update()
    {
        // ゲーム開始の処理
        if (gameProgression.gameStart)
        {
            StageLevel();
            gameProgression.DestroyEnemy();
            gameProgression.DestroyParticle();

            // 各機能を初期化(別クラス)
            resetBullet = true;
            resetBarricade = true;
            gameProgression.gameStart = false;
            
            // バリケードを表示
            barricadeObject.SetActive(true);
            
            // 大砲の向きを初期化
            cannonOblect.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            CreateEnemy();
        }

        EnemyCount();

        // 生成した敵が全ていなくなれば
        if (enemyParent.childCount <= 0)
        {
            clear = true;
            Invoke("StageClear", 2.0f);    
        }
    }

    private void CreateEnemy()
    {
        // 画面外時の速度を設定
        PlayerPrefs.SetFloat("STANDBYSPEED", stageData.standbyFall);
        // 画面内時の速度を設定
        PlayerPrefs.SetFloat("ENEMYSPEED", stageData.setSpeed);
        // StageDateで設定したData配置を配置
        for (int i = 0; i < stageData.objectDatas.Length; i++)
        {
            // 設定する場合
            /*
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            // 各インスタンスに個別のタイプを設定
            enemy.moveType = stageData.objectDatas[i].moveType;
            // Y座標の開始位置を画面外になるように代入
            Vector2 setStartPos = new Vector2(stageData.objectDatas[i].startPosX, stageData.objectDatas[i].startPosY + correctionPosY);
            Instantiate(enemyObject, setStartPos, Quaternion.identity, enemyParent)
            */

            // ランダムの場合
            MoveType randMoveType;
            Enemy enemy = enemyObject.GetComponent<Enemy>();

            // enum型の要素を取得
            int maxCount = System.Enum.GetNames(typeof(MoveType)).Length;
            // ランダムな整数を取得
            int typeNum = Random.Range(0, maxCount);
            // int型からenum型に変換
            randMoveType = (MoveType)System.Enum.ToObject(typeof(MoveType), typeNum);
            // 
            enemy.moveType = randMoveType;
            // Y座標の開始位置を画面外になるように代入
            var startPosX = Random.Range(-2.0f, 2.0f);
            Vector2 setStartPos = new Vector2(startPosX, stageData.objectDatas[i].startPosY + correctionPosY);
            Instantiate(enemyObject, setStartPos, Quaternion.identity, enemyParent);
        }
    }

    // 残りのミサイルを表示する
    private void EnemyCount()
    {
        enemyCountText.text = enemyParent.childCount.ToString("0");
    }


    // 選択された難易度のステージを設定する
    private void StageLevel()
    {
        switch (gameProgression.level)
        {
            case Level.Easy:
                stageData = easyStageData;
                break;
            case Level.Normal:
                stageData = normalStageData;
                break;
            case Level.Hard:
                stageData = hardStageData;
                break;
            case Level.VeryHard:
                stageData = veryHardStageData;
                break;
            case Level.Extreme:
                stageData = extremeStageData;
                break;
        }
    }

    public void StageClear()
    {
        if (clear)
        {
            clear = false;
            gameData.expPoint += clearPoint;
            // ポイントの情報を保存する
            PlayerPrefs.SetInt("POINT", gameData.expPoint);
            changeScene.ChangeGameClearScene();
        }
    }
}
