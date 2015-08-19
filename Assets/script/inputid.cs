using UnityEngine;


public class inputid : MonoBehaviour
{
	public static string name = "";
	public static string room_no = "";
	void OnGUI()
	{
		Rect rect1 = new Rect(200, 80, 200, 30);
		name = GUI.TextField(rect1, name, 16);

		Rect rect2 = new Rect(200, 140, 200, 30);
		room_no = GUI.TextField(rect2, room_no, 16);


	}

}