using UnityEngine;
using System.Collections;

public class logout : MonoBehaviour {

	
	public WWW POSTlogout(string url) {
		WWWForm form = new WWWForm();
		form.AddField("play_id" ,tesuto.play_id.ToString());
		Debug.Log (tesuto.play_id.ToString ());
		form.AddField("user_id" ,tesuto.user_id.ToString());
		Debug.Log (tesuto.user_id.ToString ());
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));
		return www;
	}
	private IEnumerator WaitForRequest(WWW www) {
		yield return www;

		Application.LoadLevel("title");
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			string url = "http://192.168.3.83:3000/users/logout";
			POSTlogout(url);
		}
	}
}
