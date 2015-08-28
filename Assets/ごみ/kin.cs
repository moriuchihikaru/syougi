using UnityEngine;
using System.Collections;
using System;

public class kin: MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;
	// Use this for initialization
	int click;
	float pastx;
	float pasty;
	void Start () {
		pastx = transform.position.x;
		pasty = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)&&(transform.localPosition.x==Mathf.RoundToInt(screenToWorldPointPosition.x)&&(transform.localPosition.y==Mathf.RoundToInt(screenToWorldPointPosition.y))))
			click = 1;
		if (Input.GetMouseButtonUp (0)) {
			//if(transform.position.x != pastx || transform.position.y != pasty )
			if( (transform.position.y == pasty+1  && transform.position.x == pastx+1)
			   ||(transform.position.y == pasty+1  && transform.position.x == pastx-1)
			   ||(transform.position.y == pasty+1  && transform.position.x == pastx)
			   ||(transform.position.y == pasty  && transform.position.x == pastx+1)
			   ||(transform.position.y == pasty  && transform.position.x == pastx-1)
			   ||(transform.position.y == pasty-1  && transform.position.x == pastx)

			   ){
			}//　金
			else{
				transform.position = new Vector3 (
					pastx,
					pasty, 
					screenToWorldPointPosition.z);
			}
			pastx = transform.position.x;
			pasty = transform.position.y;
			
			click = 0;
		}
		
		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 3;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint (position);
		// ワールド座標に変換されたマウス座標を代入
		
		
		if (click==1) {
			
			
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