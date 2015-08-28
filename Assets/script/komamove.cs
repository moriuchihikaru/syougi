using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using MiniJSON;

public class komamove: MonoBehaviour {
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
	int switchdes;
	string getid;
	public static int destroykomaid;
	static public int destroykoma;
	public WWW POSTupdate(string url) {
		WWWForm form = new WWWForm ();
		//tesuto.turn_count++;
		form.AddField ("play_id", tesuto.play_id.ToString ());
		Debug.Log (tesuto.play_id.ToString ());
		form.AddField ("user_id", tesuto.user_id.ToString ());
		Debug.Log (tesuto.user_id.ToString ());
		form.AddField ("move_id", komaid);
		form.AddField ("posx", (int)(10 - transform.position.x));	
		form.AddField ("posy", (int)(10 - transform.position.y));

		ban.komaseting[9- (int)transform.position.y, (int)transform.position.x - 1]=komaid;
		for (int a1 = 0; a1<9; a1++)
			for (int a2 = 0; a2<9; a2++) 
				Debug.Log(ban.komaseting [a1, a2]);
		form.AddField ("promote", "false");
	//	Debug.Log ( (int)transform.position.x-1);
	//	Debug.Log ( 9-(int)transform.position.y);
	//	if (ban.komaseting [(int)transform.position.x-1, 9-(int)transform.position.y]== 0)


			//	if (ban.komaseting [a1, a2] != ban.pastkomaseting [a1, a2]) {
			//	Debug.Log (ban.komaseting [a1, a2]);
				form.AddField ("get_id", destroykomaid);
		ban.pastkomaseting [9- (int)transform.position.y, (int)transform.position.x - 1]=komaid;
					
		//		}
//	else
//		form.AddField("get_id",ban.komaseting[(int)transform.position.x-1,9-(int)transform.position.y]);
		WWW www = new WWW(url, form);
		StartCoroutine(POSTWaitForRequest(www));
		return www;
	}
	private IEnumerator POSTWaitForRequest(WWW www) {
		yield return www;
		if (www.error == null) {
			
			
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log ("WWW Ok!: " + www.text);
			
		} else {
			Debug.Log ("WWW Error: " + www.error);
		}
	}
	private void komaidsetti(){
	//	ban.komaseting [9 - (int)pasty, (int)pastx - 1] = 0;
		pastx=transform.position.x;
		pasty=transform.position.y;
			string url = "http://192.168.3.83:3000/plays/update";
			POSTupdate(url);
	}

	void Start () {
		pastx = transform.position.x;
		pasty = transform.position.y;
		komaid = ban.komaseting [9- (int)transform.position.y, (int)transform.position.x - 1];
	}
	
	// Update is called once per frame
	void Update () {
		destroykoma = -1;
		if (ban.count == 99) {
			//	Debug.Log(komaid);
			if (ban.tekimoveposiid == komaid /*&& ban.tekimoveposiid == ban.komaseting[5,5]*/) {
				Vector3 pos = transform.position;
				pos.x = 1 + ban.tekimoveposix;
				pos.y = 9 - ban.tekimoveposiy;
				transform.position = pos;
				ban.tekimoveposiid = 0;
				Debug.Log ("ok");
			}
		}

		//	if(turn.myturn==(turn.nowturn-1)%2)
		if (Input.GetMouseButtonDown (0) && (transform.localPosition.x == Mathf.RoundToInt (screenToWorldPointPosition.x) && (transform.localPosition.y == Mathf.RoundToInt (screenToWorldPointPosition.y)))) {
			click = 1;
			pastx = transform.position.x;
			pasty = transform.position.y;
			destroykoma=-1;

		}
		//	if(turn.myturn==(turn.nowturn-1)%2)
		if (Input.GetMouseButtonUp (0)&&click==1) {
			//	if(turn.myturn+==tesuto.turn_count%2)
			if (
				(transform.position.y == pasty + 1 && (transform.position.x == pastx && komaid >= 1 && komaid <= 9)) || //ふ
			 
				(komaid >= 19 && komaid <= 20 && transform.position.y >= pasty + 1 && transform.position.x == pastx) || //きょう

				(komaid >= 23 && komaid <= 24 && (transform.position.y == pasty + 2 && transform.position.x == pastx + 1)) ||
				(komaid >= 23 && komaid <= 24 && (transform.position.y == pasty + 2 && transform.position.x == pastx - 1)) || //けい

				(komaid >= 27 && komaid <= 28 && (transform.position.y == pasty + 1 && transform.position.x == pastx + 1)) ||
				(komaid >= 27 && komaid <= 28 && (transform.position.y == pasty + 1 && transform.position.x == pastx - 1)) ||
				(komaid >= 27 && komaid <= 28 && (transform.position.y == pasty + 1 && transform.position.x == pastx)) ||
				(komaid >= 27 && komaid <= 28 && (transform.position.y == pasty - 1 && transform.position.x == pastx + 1)) ||
				(komaid >= 27 && komaid <= 28 && (transform.position.y == pasty - 1 && transform.position.x == pastx - 1)) || //ぎん

				(komaid >= 31 && komaid <= 32 && (transform.position.y == pasty + 1 && transform.position.x == pastx - 1)) ||
				(komaid >= 31 && komaid <= 32 && (transform.position.y == pasty + 1 && transform.position.x == pastx)) ||
				(komaid >= 31 && komaid <= 32 && (transform.position.y == pasty + 1 && transform.position.x == pastx + 1)) ||
				(komaid >= 31 && komaid <= 32 && (transform.position.y == pasty && transform.position.x == pastx - 1)) ||
				(komaid >= 31 && komaid <= 32 && (transform.position.y == pasty && transform.position.x == pastx + 1)) ||
				(komaid >= 31 && komaid <= 32 && (transform.position.y == pasty - 1 && transform.position.x == pastx)) || //きん

				(komaid == 35 && (transform.position.x != pastx && transform.position.y == pasty)) ||
				(komaid == 35 && (transform.position.x == pastx && transform.position.y != pasty)) || //ひしゃ

				(komaid == 37 && (System.Math.Abs (transform.position.y - pasty) == System.Math.Abs (transform.position.x - pastx)) &&
				(transform.position.x != pastx)) || //かく

				(komaid == 39 && (transform.position.y == pasty + 1 && transform.position.x == pastx + 1)) ||
				(komaid == 39 && (transform.position.y == pasty && transform.position.x == pastx + 1)) ||
				(komaid == 39 && (transform.position.y == pasty - 1 && transform.position.x == pastx + 1)) ||
				(komaid == 39 && (transform.position.y == pasty + 1 && transform.position.x == pastx)) ||
				(komaid == 39 && (transform.position.y == pasty - 1 && transform.position.x == pastx)) ||
				(komaid == 39 && (transform.position.y == pasty + 1 && transform.position.x == pastx - 1)) ||
				(komaid == 39 && (transform.position.y == pasty && transform.position.x == pastx - 1)) ||
				(komaid == 39 && (transform.position.y == pasty - 1 && transform.position.x == pastx - 1))//ぎょく 
				||


				(transform.position.y == pasty - 1 && (transform.position.x == pastx && komaid >= 10 && komaid <= 18)) || //ふ
				
				(komaid >= 21 && komaid <= 22 && transform.position.y <= pasty - 1 && transform.position.x == pastx) || //きょう
				
				(komaid >= 25 && komaid <= 26 && (transform.position.y == pasty - 2 && transform.position.x == pastx + 1)) ||
				(komaid >= 25 && komaid <= 26 && (transform.position.y == pasty - 2 && transform.position.x == pastx - 1)) || //けい
				
				(komaid >= 29 && komaid <= 30 && (transform.position.y == pasty + 1 && transform.position.x == pastx + 1)) ||
				(komaid >= 29 && komaid <= 30 && (transform.position.y == pasty + 1 && transform.position.x == pastx - 1)) ||
				(komaid >= 29 && komaid <= 30 && (transform.position.y == pasty - 1 && transform.position.x == pastx)) ||
				(komaid >= 29 && komaid <= 30 && (transform.position.y == pasty - 1 && transform.position.x == pastx + 1)) ||
				(komaid >= 29 && komaid <= 30 && (transform.position.y == pasty - 1 && transform.position.x == pastx - 1)) || //ぎん
				
				(komaid >= 33 && komaid <= 34 && (transform.position.y == pasty - 1 && transform.position.x == pastx - 1)) ||
				(komaid >= 33 && komaid <= 34 && (transform.position.y == pasty + 1 && transform.position.x == pastx)) ||
				(komaid >= 33 && komaid <= 34 && (transform.position.y == pasty - 1 && transform.position.x == pastx + 1)) ||
				(komaid >= 33 && komaid <= 34 && (transform.position.y == pasty && transform.position.x == pastx - 1)) ||
				(komaid >= 33 && komaid <= 34 && (transform.position.y == pasty && transform.position.x == pastx + 1)) ||
				(komaid >= 33 && komaid <= 34 && (transform.position.y == pasty - 1 && transform.position.x == pastx)) || //きん
				
				(komaid == 36 && (transform.position.x != pastx && transform.position.y == pasty)) ||
				(komaid == 36 && (transform.position.x == pastx && transform.position.y != pasty)) || //ひしゃ
				
				(komaid == 38 && (System.Math.Abs (transform.position.y - pasty) == System.Math.Abs (transform.position.x - pastx)) &&
				(transform.position.x != pastx)) || //かく
				
				(komaid == 40 && (transform.position.y == pasty + 1 && transform.position.x == pastx + 1)) ||
				(komaid == 40 && (transform.position.y == pasty && transform.position.x == pastx + 1)) ||
				(komaid == 40 && (transform.position.y == pasty - 1 && transform.position.x == pastx + 1)) ||
				(komaid == 40 && (transform.position.y == pasty + 1 && transform.position.x == pastx)) ||
				(komaid == 40 && (transform.position.y == pasty - 1 && transform.position.x == pastx)) ||
				(komaid == 40 && (transform.position.y == pasty + 1 && transform.position.x == pastx - 1)) ||
				(komaid == 40 && (transform.position.y == pasty && transform.position.x == pastx - 1)) ||
				(komaid == 40 && (transform.position.y == pasty - 1 && transform.position.x == pastx - 1))//ぎょく 
			 ) {
				destroykomaid =  ban.komaseting [9- (int)transform.position.y, (int)transform.position.x - 1];
				komaidsetti ();
				Debug.Log(komaid);
			}

			transform.position = new Vector3 (
					pastx,
					pasty, 
					0);
			//}
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
				Mathf.RoundToInt(screenToWorldPointPosition.x),
				Mathf.RoundToInt (screenToWorldPointPosition.y), 
				-1);
		} else {
			transform.position = new Vector3 (
				transform.position.x,
				transform.position.y, 
				0);
		}
		if (ban.count == 1) {
			for (int a1 = 0; a1<9; a1++)
				for (int a2 = 0; a2<9; a2++) 
					if (ban.komaseting [a1, a2] == komaid) {
						destroykomaid = komaid;
						destroykoma = 1;	
					}
			if (destroykoma == -1) {
				Destroy (gameObject);
			}
		}
		//if(ban.destroyid[komaid]==-1)
		//	Destroy (gameObject);	
	}
}