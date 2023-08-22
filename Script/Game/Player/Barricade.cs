using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �o���P�[�h�̏���
/// </summary>
public class Barricade : MonoBehaviour
{
    private float barricadeHP;

    [Header("Material")]
    [SerializeField] Material colorA;
    [SerializeField] Material colorB;
    [SerializeField] Material colorC;
    [Header("Component")]
    [SerializeField] GameData gameData;
    [SerializeField] CreateStage createStage;
    
    void Update()
    {
        if (createStage.resetBarricade)
        {
            createStage.resetBarricade = false;
            ResetBarricade();
        }
    }

    // �o���P�[�h�Ƀ_���[�W�����鏈��
    private void Damage()
    {
        var hitDamage = 1;
        barricadeHP -= hitDamage;
        BarricadeCheck();
    }

    // �Q�[���J�n���Ƀo���P�[�h�̏�Ԃ�߂�
    private void ResetBarricade()
    {
        // �Q�[���f�[�^����o���P�[�h�̃X�e�[�^�X���擾
        barricadeHP = gameData.defenseStatus;
        BarricadeCheck();
    }

    // �o���P�[�h�̏��
    private void BarricadeCheck()
    {
        // �o���P�[�h�̗͂�0�ɂȂ�������ł���
        switch (barricadeHP)
        {
            case 0:
                this.gameObject.SetActive(false);
                break;
            case 1:
                GetComponent<SpriteRenderer>().material.color = colorA.color;
                break;
            case 2:
                GetComponent<SpriteRenderer>().material.color = colorB.color;
                break;
            case 3:
                GetComponent<SpriteRenderer>().material.color = colorC.color;
                break;
        }
    }

    // �G�̏Փ˔��菈��
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
    }
}
