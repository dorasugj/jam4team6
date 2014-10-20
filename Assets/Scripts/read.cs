using UnityEngine;
using System.Collections;

public class read : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("Text");
		}
		for(int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			if(touch.phase == TouchPhase.Began)
			{
				Application.LoadLevel("Text");
			}
		}
	}
}
