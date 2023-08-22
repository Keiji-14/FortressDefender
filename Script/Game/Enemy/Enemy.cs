using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̓��쏈��
/// </summary>
public class Enemy : MonoBehaviour
{
	public const string mainCameraTag = "MainCamera";

	public bool rendered = false;
	public MoveType moveType;

	private float speed;
	private float standbyFall;
	private GameObject playSEObject;
	private GameObject particleParent;

	[SerializeField] ParticleSystem explosion;
	[SerializeField] PlaySE playSE;
	Rigidbody2D rb;

	void Start()
	{
		playSEObject = GameObject.FindWithTag("SE");
		particleParent = GameObject.FindWithTag("Particle");

		rb = GetComponent<Rigidbody2D>();
		playSE = playSEObject.GetComponent<PlaySE>();
		speed = PlayerPrefs.GetFloat("ENEMYSPEED", 0);
		standbyFall = PlayerPrefs.GetFloat("STANDBYSPEED", 0);
	}

	void Update()
    {
		if (rendered)
        {
			this.gameObject.layer = LayerMask.NameToLayer("Enemy");
			MovePattern();
		} 
		else
        {
			rb.AddForce(-transform.up * standbyFall);
		}
    }

	// �ݒ肳�ꂽmoveType�ɂ���ē��삷��
	private void MovePattern()
    {
		switch (moveType)
        {
			case MoveType.Straight:
				break;
			case MoveType.Right:
				this.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 25.0f), 3.0f);
				break;
			case MoveType.Left:
				this.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, -25.0f), 3.0f);
				break;
        }
		rb.AddForce(-transform.up * speed);

		MoveCorrection();
	}

	// ���E�̉�ʊO�ɏo�����ɂȂ�����^�C�v��ύX���ďo�Ȃ��悤�ɂ���
	private void MoveCorrection()
    {
		if (this.transform.position.x <= -2.0f)
        {
			moveType = MoveType.Right;
		}
		if (this.transform.position.x >= 2.0f)
		{
			moveType = MoveType.Left;
		}
	}

	// �J�����Ɉڂ������̊m�F����
	public void OnWillRenderObject()
	{
		//���C���J�����ɉf���������� Rendered ��L����
		if (Camera.current.tag == mainCameraTag)
		{
			rendered = true;
		}
	}

	// �e�̏Փ˔��菈��
	public void OnCollisionEnter2D(Collision2D collision)
	{
		// ��ʂɉf��܂ł͓����蔻��͕\������Ȃ�
		// �e�ɓ�����Ə��ł�����
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Destroy(this.gameObject);
			playSE.DestroySE();
			Instantiate(explosion, this.transform.position, Quaternion.identity, particleParent.transform);
		}
		if (collision.gameObject.CompareTag("Barricade"))
        {
			Destroy(this.gameObject);
			playSE.DestroySE();
			Instantiate(explosion, this.transform.position, Quaternion.identity, particleParent.transform);
		}
	}
}
