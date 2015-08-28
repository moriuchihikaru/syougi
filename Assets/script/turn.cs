using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class turn : MonoBehaviour {
	public WWW turnGET(string url) {
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequeststate (www));
		return www;
	}
	public static int nowturn;
	private IEnumerator WaitForRequeststate(WWW www) {
		yield return www;
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			nowturn=(int)(long)json["turn_count"];
			Debug.Log(nowturn);
			tesuto.turn_player=((int)(long)json["turn_player"]);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
	public static int myturn=1;//先手0　後手1 観戦2

	public static int bugbousi;

	void Update(){

	//	if (ban.count == 50) {
	//		Debug.Log (tesuto.turn_count+"turn");
			string url = "http://192.168.3.83:3000/plays/"+ tesuto.play_id.ToString ();
	//		turnGET(url);
	//	}
//	}
}
}