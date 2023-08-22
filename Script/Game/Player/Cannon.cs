using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��C�̑���֌W
/// </summary>
public class Cannon : MonoBehaviour
{
	public bool shot;

	void Update()
	{
		// ��ʂ��^�b�v���Ă���Ԃ͖C��𑀍�ł���
		if (Input.GetMouseButton(0) && !shot)
		{
			var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
			var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
			if (Input.mousePosition.y > 250f)
			{
				transform.localRotation = rotation;
			}
		}
	}
}
