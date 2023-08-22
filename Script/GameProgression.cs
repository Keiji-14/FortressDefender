using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    Title,
    StageSelect,
    Game,
    GameOver,
    GameClear,
    Upgrade,
    Help
}

/// <summary>
/// ゲームの流れを管理
/// </summary>
public class GameProgression : MonoBehaviour
{
    public GameStatus gameStatus;

    [Header("Title")]
    [SerializeField] GameObject titleScene;
    [SerializeField] GameObject stageSelectScene;

    [Header("SelectStage")]
    public Level level;

    [Header("Game")]
    public bool gameStart;
    [SerializeField] GameObject gameScene;

    [Header("GameOver")]
    [SerializeField] GameObject gameOverScene;

    [Header("GameClear")]
    [SerializeField] GameObject gameClearScene;

    [Header("Upgrade")]
    [SerializeField] GameObject upgradeScene;

    [Header("Help")]
    [SerializeField] GameObject helpScene;

    [Header("Transfrom")]
    [SerializeField] Transform createEnemy;
    [SerializeField] Transform createParticle;

    void Start()
    {
        // 始めにタイトルを表示する
        gameStatus = GameStatus.Title;
    }

    void Update()
    {
        switch (gameStatus)
        {
            case GameStatus.Title:
                TitleProcess();
                break;
            case GameStatus.StageSelect:
                StageSelectProcess();
                break;
            case GameStatus.Game:
                GameProcess();
                break;
            case GameStatus.GameOver:
                GameOverProcess();
                break;
            case GameStatus.GameClear:
                GameClearProcess();
                break;
            case GameStatus.Upgrade:
                UpgradeProcess();
                break;
            case GameStatus.Help:
                HelpProcess();
                break;
                
        }
    }

    // タイトル画面の表示
    private void TitleProcess()
    {
        titleScene.SetActive(true);
        stageSelectScene.SetActive(false);
        gameScene.SetActive(false);
        gameOverScene.SetActive(false);
        gameClearScene.SetActive(false);
        upgradeScene.SetActive(false);
        helpScene.SetActive(false);
    }

    // ステージ選択画面の表示
    private void StageSelectProcess()
    {
        stageSelectScene.SetActive(true);
        titleScene.SetActive(false);
        gameOverScene.SetActive(false);
        gameClearScene.SetActive(false);
    }

    // ゲーム画面の表示
    private void GameProcess()
    {
        gameScene.SetActive(true);
        stageSelectScene.SetActive(false);
        gameOverScene.SetActive(false);
        gameClearScene.SetActive(false);
    }

    // ゲームオーバー画面の表示
    private void GameOverProcess()
    {
        gameScene.SetActive(false);
        gameOverScene.SetActive(true);
        DestroyEnemy();
        DestroyParticle();
    }

    // 敵を全て消滅させる（リトライ時に敵が残らないようにする為）
    public void DestroyEnemy()
    {
        // 子を全て調べる
        foreach (Transform child in createEnemy)
        {
            Destroy(child.gameObject);
        }
    }

    // 残留しているエフェクトを全て消滅させる
    public void DestroyParticle()
    {
        // 子を全て調べる
        foreach (Transform child in createParticle)
        {
            Destroy(child.gameObject);
        }
    }

    // ゲームクリア画面の表示
    private void GameClearProcess()
    {
        gameScene.SetActive(false);
        gameClearScene.SetActive(true);
    }

    // 強化画面の表示
    private void UpgradeProcess()
    {
        titleScene.SetActive(false);
        upgradeScene.SetActive(true);
    }

    // 強化画面の表示
    private void HelpProcess()
    {
        titleScene.SetActive(false);
        helpScene.SetActive(true);
    }
}
