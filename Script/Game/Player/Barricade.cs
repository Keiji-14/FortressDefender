using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バリケードの処理
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

    // バリケードにダメージが入る処理
    private void Damage()
    {
        var hitDamage = 1;
        barricadeHP -= hitDamage;
        BarricadeCheck();
    }

    // ゲーム開始事にバリケードの状態を戻す
    private void ResetBarricade()
    {
        // ゲームデータからバリケードのステータスを取得
        barricadeHP = gameData.defenseStatus;
        BarricadeCheck();
    }

    // バリケードの状態
    private void BarricadeCheck()
    {
        // バリケード体力が0になったら消滅する
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

    // 敵の衝突判定処理
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
    }
}
