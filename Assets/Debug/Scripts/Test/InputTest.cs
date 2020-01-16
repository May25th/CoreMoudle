using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//这里会打印出所有的按键操作
		foreach (KeyCode item in  System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown (item)) {
				CDebug.Log (item.ToString());
			}
		}
	}
}
