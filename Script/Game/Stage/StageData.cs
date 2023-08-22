using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    Straight,
    Right,
    Left,
}

/// <summary>
/// �~�T�C���̔z�u��StageData�ŕҏW����ScriptableObject
/// </summary>
[CreateAssetMenu(menuName = "MyScriptable/Create StageData")]
public class StageData : ScriptableObject
{
    [System.Serializable]
    public class ObjectDatas
    {
        [Range(-2.5f, 2.5f)]
        public float startPosX;
        public float startPosY;
        public MoveType moveType;
    }

    // �X�e�[�W�̓G�̑��x�����ʂɂ���
    public float standbyFall;
    public float setSpeed;
    public ObjectDatas[] objectDatas;
    
}
