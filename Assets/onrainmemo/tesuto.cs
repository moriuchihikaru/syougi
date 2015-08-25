using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using UnityEngine.Events;
public class tesuto : MonoBehaviour {

	public WWW stateGET(string url) {
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequeststate (www));
		return www;
	}
	public WWW loginPOST(string url,UnityAction<string> call= null) {
		WWWForm form = new WWWForm();
		form.AddField("name" ,inputid.name);
		form.AddField("room_no" ,inputid.room_no);
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequestlogin(www, call));

		return www;
	}

	private IEnumerator WaitForRequeststate(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);
			
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log ((string)json["state"]);
		//	if((string)json["state"]==(string)"waiting")
		//		stateswitch=1;
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
	private IEnumerator WaitForRequestlogin(WWW www,UnityAction<string> call= null) {
		yield return www;

		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);

			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log ((string)json["state"]);
			user_id=((long)json["user_id"]);
			play_id=((long)json["play_id"]);
			if(((string)json["role"])=="watcher")
				turn.myturn=2;
			Debug.Log (inputid.name);
			Debug.Log (inputid.room_no);
			string turnurl = "http://192.168.3.83:3000/plays/" + tesuto.play_id.ToString ();
			GETturn (turnurl);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
		if (call != null)
			call (www.text);
	}

	public WWW GETturn(string turnurl) {
		WWW www = new WWW (turnurl);
		StartCoroutine (WaitForRequestturn (www));
		return www;
	}
	private IEnumerator WaitForRequestturn(WWW www) {
		yield return www;
		
		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);
			
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
	//		Debug.Log ((long)json["turn_count"]);
			turn_count=((int)(long)json["turn_count"]);
			Debug.Log (turn_count);
			turn_player=((int)(long)json["turn_player"]);
			Debug.Log(turn_player);
			Debug.Log (user_id);
			if(turn_player==user_id)
			{
				turn.myturn=1;

			};

		//自分が後手
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
		
	}

	static public int turn_count;
	static public int turn_player;

	static public long user_id;
	static public long play_id;
	static public int stateswitch=0;

	// Use this for initialization
	void Start () {
		string loginurl = "http://192.168.3.83:3000/users/login";
		loginPOST (loginurl, hoge);


		
		
	}

	void hoge(string text) {
		
		Debug.Log (play_id);
		string stateurl = "http://192.168.3.83:3000/plays/"+play_id.ToString()+"/state";
		Debug.Log (stateurl);
		stateGET (stateurl);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
