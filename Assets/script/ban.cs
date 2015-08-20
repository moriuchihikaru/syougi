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
	private void komahaiti(){
		int a1;
		int a2;

			for (a1 = 0; a1<9; a1++)
				for (a2 = 0; a2<9; a2++) {
			komaposi.y = 9 - a1;
			komaposi.x = a2 + 1;
					
			if (komaseting [a1, a2] <= 9 && komaseting [a1, a2] >= 1) {
				Instantiate (hu, komaposi,transform.rotation);
			}//ふ
			if (komaseting [a1, a2] <= 20 && komaseting [a1, a2] >= 19) {
				Instantiate (kyou, komaposi,transform.rotation);
			}//きょう
			if (komaseting [a1, a2] <= 24 && komaseting [a1, a2] >= 23) {
				Instantiate (kei, komaposi,transform.rotation);
			}//けい
			if (komaseting [a1, a2] <= 28 && komaseting [a1, a2] >= 27) {
				Instantiate (gin, komaposi,transform.rotation);
			}//ぎん
			if (komaseting [a1, a2] <= 32 && komaseting [a1, a2] >= 31) {
				Instantiate (kin, komaposi,transform.rotation);
			}//きん
			if (komaseting [a1, a2] == 35) {
				Instantiate (hisya,komaposi,transform.rotation);
			}//ひしゃ
			if (komaseting [a1, a2] == 37) {
				Instantiate (kaku, komaposi,transform.rotation);
			}//かく
			if (komaseting [a1, a2] == 39) {
				Instantiate (gyoku, komaposi,transform.rotation);
			}//おう

		}
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
			komaseting[posy,posx]=komaid;
			pastkomaseting[posy,posx]=komaid;
			Debug.Log ((string)piece["name"]);

			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
		if (switchkomaset == 0)
			komahaiti ();
		else {
		}
		switchkomaset = 1;


	}

	public GameObject hu;
	public GameObject kyou;
	public GameObject kei;
	public GameObject gin;
	public GameObject kin;
	public GameObject hisya;
	public GameObject kaku;
	public GameObject gyoku;

	 public static int [,] komaseting =new int [9,9]{
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
	int [,] pastkomaseting = new int[9,9];
	private int switchkomaset;
	private int posx;
	private int posy;
	private int komaid;
	public static int count;
	Vector2 mouseposition;
	
	public static Vector3 komaposi;

	public WWW POSTupdate(string url) {
		WWWForm form = new WWWForm();
		form.AddField("name" ,inputid.name);
		form.AddField("room_no" ,inputid.room_no);
		WWW www = new WWW(url, form);
		StartCoroutine(WaitForRequest(www));
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
	// Use this for initialization
	void Start () {
		string url = "http://192.168.3.83:3000/get_pieces.json";
		GET (url);

	}
	
	// Update is called once per frame
	void Update () {


		count++;
		if (count == 200) {
			string url = "http://192.168.3.83:3000/get_pieces.json";
			GET (url);
			count = 0;
			int a1;
			int a2;
			for (a1 = 0; a1<9; a1++)
			for (a2 = 0; a2<9; a2++) 
				Debug.Log (komaseting [a1, a2] + "y" + a1 + "x" + a2);

		//	string update = "http://192.168.3.83:3000/plays/update";
		//	POSTupdate(update);

		}

	}
}
