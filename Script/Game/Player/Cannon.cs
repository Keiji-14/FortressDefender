using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大砲の操作関係
/// </summary>
public class Cannon : MonoBehaviour
{
	public bool shot;

	void Update()
	{
		// 画面をタップしている間は砲台を操作できる
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
