using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class tesuto : MonoBehaviour {

	public WWW GET(string url) {
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
		return www;
	}
	public WWW POST(string url) {
		WWWForm form = new WWWForm();
		form.AddField("name" ,inputid.name);
		form.AddField("room_no" ,inputid.room_no);
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));
		return www;
	}

	private IEnumerator WaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);

			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log ((string)json["state"]);
		
			Debug.Log (inputid.name);
			Debug.Log (inputid.room_no);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}

	static public string user_id;
	static public string play_id;

	// Use this for initialization
	void Start () {
		string url = "http://192.168.3.83:3000/plays/1/state";
		GET (url);
		url = "http://192.168.3.83:3000/users/login";
		POST (url);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
