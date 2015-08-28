using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class json : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var textAsset = Resources.Load ("sample") as TextAsset;
		var jsonText = textAsset.text;
		
		// 文字列を json に合わせて構成された辞書に変換
		var json = Json.Deserialize (jsonText) as Dictionary<string, object>;

//		Debug.Log ((string)json["name"]);
//		Debug.Log ((long)json["age"]);
//		Debug.Log ((string)json["bloodType"]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
