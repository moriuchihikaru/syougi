using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using MiniJSON;

public class hu: MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;
	// Use this for initialization
	int click;
	float pastx;
	float pasty;
	int komaid;

	int komax;
	int komay;

	public WWW POSTupdate(string url) {
		WWWForm form = new WWWForm();
		form.AddField("play_id" ,tesuto.play_id);
		form.AddField("user_id" ,tesuto.user_id);
		form.AddField("move_id" ,komaid);
		form.AddField("posx",(int)(9-transform.position.x));
		form.AddField("posy",(int)transform.position.y);
		form.AddField("promote","false");
		form.AddField("get_id","-1");
		WWW www = new WWW(url, form);
		StartCoroutine(POSTWaitForRequest(www));
		return www;
	}
	private IEnumerator POSTWaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null) {
			
			
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log ("WWW Ok!: " + www.text);
			
		} else {
			Debug.Log ("WWW Error: " + www.error);
		}
	}


	void Start () {
		pastx = transform.position.x;
		pasty = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(ban.count==200)
		for (; komax<9; komax++)
			for (; komay<9; komay++)
				if (komaid == ban.komaseting [komay, komax]) {
					transform.localPosition = new Vector3 (komax, komay, -1);
				break;
				}

		if (Input.GetMouseButtonDown (0) && (transform.localPosition.x == Mathf.RoundToInt (screenToWorldPointPosition.x) && (transform.localPosition.y == Mathf.RoundToInt (screenToWorldPointPosition.y)))){
			click = 1;
		pastx = transform.position.x;
		pasty = transform.position.y;
			komaid = ban.komaseting [9- (int)transform.position.y, (int)transform.position.x - 1];
	}
		if (Input.GetMouseButtonUp (0)) {
				if(transform.position.y == pasty+1  && transform.position.x == pastx ){
				ban.komaseting [9-(int)pasty, (int)pastx-1]=0;
				ban.komaseting [9- (int)transform.position.y, (int)transform.position.x - 1]  = komaid;


			//	string update = "http://192.168.3.83:3000/plays/update";
				//	POSTupdate(update);


			}//　ふのばあいのみ
				else{
			transform.position = new Vector3 (
					pastx,
					pasty, 
					screenToWorldPointPosition.z);
			}
			click = 0;
		}
		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 3;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint (position);
		// ワールド座標に変換されたマウス座標を代入
		if (click == 1) {
			transform.position = new Vector3 (
				Mathf.RoundToInt (screenToWorldPointPosition.x),
				Mathf.RoundToInt (screenToWorldPointPosition.y), 
				-1);
		} else {
			transform.position = new Vector3 (
				transform.position.x,
				transform.position.y, 
				0);
		}
	}
}