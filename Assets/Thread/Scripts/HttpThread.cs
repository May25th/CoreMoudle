using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class HttpThread{

	private int index;
	public void Check()
	{
		Debug.Log ("System.Net.ServicePointManager.DefaultConnectionLimit " + System.Net.ServicePointManager.DefaultConnectionLimit);
		for (int i = 0; i < 10000; i++) {
			Debug.Log ("HttpThread" + "->" + i);
		}
	}
}
