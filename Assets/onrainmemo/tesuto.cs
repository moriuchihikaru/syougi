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
			Debug.Log (inputid.name);
			Debug.Log (inputid.room_no);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
		if (call != null)
			call (www.text);
	}

	static public long user_id;
	static public long play_id;

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
