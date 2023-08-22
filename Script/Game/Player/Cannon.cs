using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‘å–C‚Ì‘€ìŠÖŒW
/// </summary>
public class Cannon : MonoBehaviour
{
	public bool shot;

	void Update()
	{
		// ‰æ–Ê‚ğƒ^ƒbƒv‚µ‚Ä‚¢‚éŠÔ‚Í–C‘ä‚ğ‘€ì‚Å‚«‚é
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
