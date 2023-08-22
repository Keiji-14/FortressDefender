using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�̏���
/// </summary>
public class Bullet : MonoBehaviour
{
	// �e�̏����ʒu
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

		// �Q�[���J�n���ɂ͒e�������l�ɂ���
		if (createStage.resetBullet)
        {
			createStage.resetBullet = false;
			ResetPos();
        }
	}

	// �e�̔��ˏ���
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

	// �����ʒu�ɖ߂�
	private void ResetPos()
	{
		cannon.shot = false;
		// ���x���[���ɂ���
		rb.velocity = Vector3.zero;
		transform.position = setFirstPos;
		this.gameObject.layer = LayerMask.NameToLayer("StandbyBullet");
	}

	// �ǂ̏Փ˔��菈��
	public void OnCollisionEnter2D(Collision2D collision)
	{
		// ��ʊO�ɂ���o�[�ɓ�����Ə����ʒu�ɖ߂�
		if (collision.gameObject.CompareTag("Wall"))
		{
			ResetPos();
		}
	}
}
