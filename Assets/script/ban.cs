using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
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
			
			
			if (komaseting [a1, a2] <= 18 && komaseting [a1, a2] >= 10) {
				Instantiate (enemyhu, komaposi,transform.rotation);
			}//ふ
			if (komaseting [a1, a2] <= 22 && komaseting [a1, a2] >= 21) {
				Instantiate (enemykyou, komaposi,transform.rotation);
			}//きょう
			if (komaseting [a1, a2] <= 26 && komaseting [a1, a2] >= 25) {
				Instantiate (enemykei, komaposi,transform.rotation);
			}//けい
			if (komaseting [a1, a2] <= 30 && komaseting [a1, a2] >= 29) {
				Instantiate (enemygin, komaposi,transform.rotation);
			}//ぎん
			if (komaseting [a1, a2] <= 34 && komaseting [a1, a2] >= 33) {
				Instantiate (enemykin, komaposi,transform.rotation);
			}//きん
			if (komaseting [a1, a2] == 36) {
				Instantiate (enemyhisya,komaposi,transform.rotation);
			}//ひしゃ
			if (komaseting [a1, a2] == 38) {
				Instantiate (enemykaku, komaposi,transform.rotation);
			}//かく
			if (komaseting [a1, a2] == 40) {
				Instantiate (enemygyoku, komaposi,transform.rotation);
			}//おう
			
			
			
			
			
			
		}
	}
	
	
	private IEnumerator WaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null) {
			
			komaid=0;
			var json = Json.Deserialize (www.text) as Dictionary<string, object>;
			Debug.Log("WWW Ok!: " + www.text);
			for (a1 = 0; a1<9; a1++)
				for (a2 = 0; a2<9; a2++)
					komaseting [a1, a2]=0;
			while(komaid<40){
				komaid++;
				var piece = (Dictionary<string, object>)json[string.Format("{0}", komaid)];
				if((int)(long)piece["posx"]!=0)
				{	posx=(int)(long)piece["posx"];
				posy=(int)(long)piece["posy"];
				posx = changecoordinatex(posx);
				posy = changecoordinatey(posy);
				//	Debug.Log (komaid);
			//	Debug.Log (posx);
			//	Debug.Log (posy);
					komaseting[posy,posx]=komaid;
				}
				//	pastkomaseting[posy,posx]=komaid;
				//	Debug.Log ((string)piece["name"]);
				
			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
		if (switchkomaset == 0) {
			komahaiti ();
			for (a1 = 0; a1<9; a1++)
				for (a2 = 0; a2<9; a2++) 
					pastkomaseting [a1, a2] = komaseting [a1, a2];
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
	
	public GameObject enemyhu;
	public GameObject enemykyou;
	public GameObject enemykei;
	public GameObject enemygin;
	public GameObject enemykin;
	public GameObject enemyhisya;
	public GameObject enemykaku;
	public GameObject enemygyoku;
	
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
	public static int [,] pastkomaseting = new int[9,9];
	private int switchkomaset;
	private int posx;
	private int posy;
	private int komaid;
	public static int count;
	Vector2 mouseposition;
	
	public static Vector3 komaposi;
	
	int a1;
	int a2;
	static public int tekimoveposix;
	static public int tekimoveposiy;
	static public int tekimoveposiid=-1;
	// Use this for initialization
	void Start () {
		//string url = "http://192.168.3.83:3000/get_pieces.json";
		//string url = "http://192.168.3.83:3000/plays/" + tesuto.play_id.ToString() + "/pieces";
		//GET (url);
		
	}
	static public int [] destroyid = new int [41];

	// Update is called once per frame
	void Update () {
		
		if(tesuto.stateswitch==0){
			count++;
			if (count == 100) {
				string url = "http://192.168.3.83:3000/plays/" + tesuto.play_id.ToString () + "/pieces";
				GET (url);
				count = 0;
				for (a1 = 0; a1<9; a1++)
				for (a2 = 0; a2<9; a2++) { 
					if (pastkomaseting [a1, a2] != komaseting [a1, a2] && komaseting [a1, a2] != 0) {
						
						tekimoveposix = a2;
						tekimoveposiy = a1;
						tekimoveposiid = komaseting [a1, a2];
						destroyid[komaseting[a1,a2]]=-1;
						//			Debug.Log(tekimoveposiid);
						//			Debug.Log (tekimoveposix + "xxxx");
						//			Debug.Log (tekimoveposiy + "yyyy");
					}
					pastkomaseting [a1, a2] = komaseting [a1, a2];
				}
			}
		}
	}
}