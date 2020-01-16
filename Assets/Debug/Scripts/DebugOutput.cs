using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DebugOutput{

	bool open = false;
	bool showLog = false;
	bool showError = false;
	bool showWarning = false;

	public string outpathLog;
	private string outpathError;
	private string outpathWarning;

    private string folderDirectory;

    public DebugOutput ()
	{
#if UNITY_EDITOR
        folderDirectory = Application.dataPath + "/StreamingAssets";
#elif UNITY_IPHONE
		folderDirectory = Application.dataPath +"/Raw"; 
#elif UNITY_ANDROID
		folderDirectory = Application.persistentDataPath; 
#endif

        outpathLog = folderDirectory + "/outLog.txt";
        outpathError = folderDirectory + "/outLogError.txt";
        outpathWarning = folderDirectory + "/outLogWarining.txt";

        if (!Directory.Exists(folderDirectory)) {
            Directory.CreateDirectory(folderDirectory);
        }

        //每次启动客户端删除之前保存的Log  
        if (System.IO.File.Exists(outpathLog)) 
		{ 
			File.Delete(outpathLog); 
		} 
		if (System.IO.File.Exists(outpathError)) 
		{
			File.Delete(outpathError);
		} 
		if (System.IO.File.Exists(outpathWarning)) 
		{ 
			File.Delete(outpathWarning); 
		}
	}
	
	public void WriteLog (string logString, string stackTrace, LogType logType) {
		switch (logType) {
		case LogType.Log:
			using (StreamWriter writer = new StreamWriter(outpathLog, true, Encoding.UTF8)) { writer.WriteLine(logString); }
			break;
		case LogType.Warning:
			using (StreamWriter writer = new StreamWriter(outpathWarning, true, Encoding.UTF8)) { writer.WriteLine(logString); }
			break;
		case LogType.Error:
			using (StreamWriter writer = new StreamWriter(outpathError, true, Encoding.UTF8)) { writer.WriteLine(logString); }
			break;
		}
	}
}
