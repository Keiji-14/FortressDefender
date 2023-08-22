using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 防衛ラインの処理
/// </summary>
public class Border : MonoBehaviour
{
	[Header("Component")]
	[SerializeField] ChangeScene changeScene;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// 敵が防衛ライン（地面）に着いたらゲームオーバー
		if (collision.gameObject.CompareTag("Enemy"))
		{
			changeScene.ChangeGameOverScene();
		}
	}
}
