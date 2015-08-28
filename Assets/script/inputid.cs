using UnityEngine;


public class inputid : MonoBehaviour
{
	public static string name = "";
	public static string room_no = "";
	void OnGUI()
	{
		;
		;
		Rect rect1 = new Rect(Screen.width/1.6f,Screen.height/3, Screen.width/5,Screen.width/30);
		name = GUI.TextField(rect1, name, Screen.width/30);

		Rect rect2 = new Rect(Screen.width/1.6f,Screen.height/2, Screen.width/5,Screen.width/30);
		room_no = GUI.TextField(rect2, room_no, Screen.width/30);


	}

}