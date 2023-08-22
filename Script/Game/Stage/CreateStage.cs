using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �G�̐����Ȃǂ̃Q�[������
/// </summary>
public class CreateStage : MonoBehaviour
{
    // �X�e�[�W�N���A�̃|�C���g
    private const int clearPoint = 1;
    // ��ʊO�̊J�n�ʒu�̒����p
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
        // �Q�[���J�n�̏���
        if (gameProgression.gameStart)
        {
            StageLevel();
            gameProgression.DestroyEnemy();
            gameProgression.DestroyParticle();

            // �e�@�\��������(�ʃN���X)
            resetBullet = true;
            resetBarricade = true;
            gameProgression.gameStart = false;
            
            // �o���P�[�h��\��
            barricadeObject.SetActive(true);
            
            // ��C�̌�����������
            cannonOblect.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            CreateEnemy();
        }

        EnemyCount();

        // ���������G���S�Ă��Ȃ��Ȃ��
        if (enemyParent.childCount <= 0)
        {
            clear = true;
            Invoke("StageClear", 2.0f);    
        }
    }

    private void CreateEnemy()
    {
        // ��ʊO���̑��x��ݒ�
        PlayerPrefs.SetFloat("STANDBYSPEED", stageData.standbyFall);
        // ��ʓ����̑��x��ݒ�
        PlayerPrefs.SetFloat("ENEMYSPEED", stageData.setSpeed);
        // StageDate�Őݒ肵��Data�z�u��z�u
        for (int i = 0; i < stageData.objectDatas.Length; i++)
        {
            // �ݒ肷��ꍇ
            /*
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            // �e�C���X�^���X�Ɍʂ̃^�C�v��ݒ�
            enemy.moveType = stageData.objectDatas[i].moveType;
            // Y���W�̊J�n�ʒu����ʊO�ɂȂ�悤�ɑ��
            Vector2 setStartPos = new Vector2(stageData.objectDatas[i].startPosX, stageData.objectDatas[i].startPosY + correctionPosY);
            Instantiate(enemyObject, setStartPos, Quaternion.identity, enemyParent)
            */

            // �����_���̏ꍇ
            MoveType randMoveType;
            Enemy enemy = enemyObject.GetComponent<Enemy>();

            // enum�^�̗v�f���擾
            int maxCount = System.Enum.GetNames(typeof(MoveType)).Length;
            // �����_���Ȑ������擾
            int typeNum = Random.Range(0, maxCount);
            // int�^����enum�^�ɕϊ�
            randMoveType = (MoveType)System.Enum.ToObject(typeof(MoveType), typeNum);
            // 
            enemy.moveType = randMoveType;
            // Y���W�̊J�n�ʒu����ʊO�ɂȂ�悤�ɑ��
            var startPosX = Random.Range(-2.0f, 2.0f);
            Vector2 setStartPos = new Vector2(startPosX, stageData.objectDatas[i].startPosY + correctionPosY);
            Instantiate(enemyObject, setStartPos, Quaternion.identity, enemyParent);
        }
    }

    // �c��̃~�T�C����\������
    private void EnemyCount()
    {
        enemyCountText.text = enemyParent.childCount.ToString("0");
    }


    // �I�����ꂽ��Փx�̃X�e�[�W��ݒ肷��
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
            // �|�C���g�̏���ۑ�����
            PlayerPrefs.SetInt("POINT", gameData.expPoint);
            changeScene.ChangeGameClearScene();
        }
    }
}
