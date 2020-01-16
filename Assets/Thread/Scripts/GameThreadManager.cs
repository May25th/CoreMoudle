using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameThreadManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartNewThread ();
	}

	private void StartNewThread()
	{
		Thread mThread = new Thread (StartOneThread);
		Thread mThread2 = new Thread (StartOneThread);
		Thread mThread3 = new Thread (StartOneThread);
		mThread.Start ("test1");
		mThread2.Start ("test2");
		mThread3.Start ("test3");
		Thread httpThread = new Thread (new HttpThread().Check);
		mThread.Priority = System.Threading.ThreadPriority.Highest;//线程的优先级
		mThread2.Priority = System.Threading.ThreadPriority.Normal;//线程的优先级
		mThread3.Priority = System.Threading.ThreadPriority.Lowest;//线程的优先级
		httpThread.Start();
	}

	private void StartOneThread(object check)
	{
		//Debug.Log ("StartOneThread " + check);
		for (int i = 0; i < 20000; i++) {
			//Thread.Sleep (10);
			Debug.Log (check + "_" + i);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
