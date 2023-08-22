using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾の処理
/// </summary>
public class Bullet : MonoBehaviour
{
	// 弾の初期位置
	private Vector2 setFirstPos;

	[Header("Component")]
	[SerializeField] GameData gameData;
	[SerializeField] CreateStage createStage;
	[SerializeField] Cannon cannon;
	[SerializeField] PlaySE playSE;

	Rigidbody2D rb;

	void Start()
	{
		transform.localScale *= gameData.sizeStatus;
		setFirstPos = new Vector2(0, -4f);
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (!cannon.shot)
		{
			Shot();
		}

		// ゲーム開始時には弾を初期値にする
		if (createStage.resetBullet)
        {
			createStage.resetBullet = false;
			ResetPos();
        }
	}

	// 弾の発射処理
	private void Shot()
    {
		if (Input.GetMouseButton(0))
		{
			var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
			var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
			if (Input.mousePosition.y > 250f)
            {
				transform.localRotation = rotation;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			cannon.shot = true;
			rb.AddForce(transform.up * gameData.speedStatus);
			this.gameObject.layer = LayerMask.NameToLayer("Bullet");
			playSE.ShotSE();
		}
	}

	// 初期位置に戻す
	private void ResetPos()
	{
		cannon.shot = false;
		// 速度をゼロにする
		rb.velocity = Vector3.zero;
		transform.position = setFirstPos;
		this.gameObject.layer = LayerMask.NameToLayer("StandbyBullet");
	}

	// 壁の衝突判定処理
	public void OnCollisionEnter2D(Collision2D collision)
	{
		// 画面外にあるバーに当たると初期位置に戻す
		if (collision.gameObject.CompareTag("Wall"))
		{
			ResetPos();
		}
	}
}
