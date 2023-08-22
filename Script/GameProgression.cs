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
/// �Q�[���̗�����Ǘ�
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
        // �n�߂Ƀ^�C�g����\������
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

    // �^�C�g����ʂ̕\��
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

    // �X�e�[�W�I����ʂ̕\��
    private void StageSelectProcess()
    {
        stageSelectScene.SetActive(true);
        titleScene.SetActive(false);
        gameOverScene.SetActive(false);
        gameClearScene.SetActive(false);
    }

    // �Q�[����ʂ̕\��
    private void GameProcess()
    {
        gameScene.SetActive(true);
        stageSelectScene.SetActive(false);
        gameOverScene.SetActive(false);
        gameClearScene.SetActive(false);
    }

    // �Q�[���I�[�o�[��ʂ̕\��
    private void GameOverProcess()
    {
        gameScene.SetActive(false);
        gameOverScene.SetActive(true);
        DestroyEnemy();
        DestroyParticle();
    }

    // �G��S�ď��ł�����i���g���C���ɓG���c��Ȃ��悤�ɂ���ׁj
    public void DestroyEnemy()
    {
        // �q��S�Ē��ׂ�
        foreach (Transform child in createEnemy)
        {
            Destroy(child.gameObject);
        }
    }

    // �c�����Ă���G�t�F�N�g��S�ď��ł�����
    public void DestroyParticle()
    {
        // �q��S�Ē��ׂ�
        foreach (Transform child in createParticle)
        {
            Destroy(child.gameObject);
        }
    }

    // �Q�[���N���A��ʂ̕\��
    private void GameClearProcess()
    {
        gameScene.SetActive(false);
        gameClearScene.SetActive(true);
    }

    // ������ʂ̕\��
    private void UpgradeProcess()
    {
        titleScene.SetActive(false);
        upgradeScene.SetActive(true);
    }

    // ������ʂ̕\��
    private void HelpProcess()
    {
        titleScene.SetActive(false);
        helpScene.SetActive(true);
    }
}
