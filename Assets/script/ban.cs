using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
public class ban : MonoBehaviour {
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
	private int changecoordinatex(int x){
		x = 9 - x;
		return x;
	}
	private int changecoordinatey(int y){
		y = y - 1;
		return y;
	}
	

	private IEnumerator WaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null) {


			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log("WWW Ok!: " + www.text);
			while(komaid<40){
				komaid++;
				var piece = (Dictionary<string, object>)json[string.Format("{0}", komaid)];
			posx=(int)(long)piece["posx"];
			posy=(int)(long)piece["posy"];
			posx = changecoordinatex(posx);
			posy = changecoordinatey(posy);
			komaseting[posx,posy]=komaid;
			Debug.Log ((string)piece["name"]);
			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}


	int [,] komaseting =new int [9,9]{
		//x-1  y-1
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0}
	};

	private int posx;
	private int posy;
	private int komaid;
	int count;
	Vector2 mouseposition;

	// Use this for initialization
	void Start () {



		
	}
	
	// Update is called once per frame
	void Update () {
		string url = "http://192.168.3.83:3000/get_pieces.json";
		GET (url);
		count++;
		if (count > 200) {
			for(int a1 = 0; a1<9; a1++)
				for(int a2 = 0; a2<9; a2++)
			Debug.Log (komaseting [a1, a2] + "aaaas");
			count = 0;

		}
	}
}
