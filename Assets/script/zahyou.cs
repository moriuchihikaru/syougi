using UnityEngine;
using System.Collections;
using System;

public class zahuou: MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			// Vector3でマウス位置座標を取得する
			position = Input.mousePosition;
			// Z軸修正
			position.z = 3;
			// マウス位置座標をスクリーン座標からワールド座標に変換する
			screenToWorldPointPosition = Camera.main.ScreenToWorldPoint (position);
			// ワールド座標に変換されたマウス座標を代入
	
			transform.position = new Vector3(
				Mathf.RoundToInt(screenToWorldPointPosition.x),
				Mathf.RoundToInt(screenToWorldPointPosition.y), 
				screenToWorldPointPosition.z);
			/*	gameObject.transform.position = screenToWorldPointPosition;
			var pos = transform.position;
			pos.x = 1;
			transform.position = pos;*/
		}
	}
}