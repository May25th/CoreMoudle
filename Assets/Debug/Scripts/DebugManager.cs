using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {

	//这个应该写一个单独的线程去处理最好

	private List<DebugLog> LogList = new List<DebugLog>();
	private DebugOutput mDebugOutput;//专门做日志输出的
	[SerializeField]
	private UnityEngine.UI.Text mPathText;
	private int index;
	void Start () {
		Debug.Log ("Start");
		Application.logMessageReceived += ReceivedLog;
		mDebugOutput = new DebugOutput ();
        if (CDebug.IsDebug == false)
        {
            mPathText.gameObject.SetActive(false);
        }
    }

	void OnDestroy()
	{
		Application.logMessageReceived -= ReceivedLog;
	}

    private int MAX_COUNT = 20;
    private string str;
    private void ReceivedLog( string logString, string stackTrace, LogType logType )
	{
		mDebugOutput.WriteLog (logString , stackTrace, logType);
        if (mPathText == null)
        {
            return;//不存在 或者应用已经关闭了
        }
        LogList.Add(new DebugLog(logString, stackTrace, logType));
        str = "";
        for (int i = Mathf.Max(0, LogList.Count - MAX_COUNT); i < LogList.Count; i++)
        {
            str = str + "\n" + LogList[i].ToString();
        }
        mPathText.text = str;
    }
}
