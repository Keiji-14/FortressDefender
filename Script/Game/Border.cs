using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �h�q���C���̏���
/// </summary>
public class Border : MonoBehaviour
{
	[Header("Component")]
	[SerializeField] ChangeScene changeScene;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// �G���h�q���C���i�n�ʁj�ɒ�������Q�[���I�[�o�[
		if (collision.gameObject.CompareTag("Enemy"))
		{
			changeScene.ChangeGameOverScene();
		}
	}
}
