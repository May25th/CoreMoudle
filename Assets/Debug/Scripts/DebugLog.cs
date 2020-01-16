using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog
{
    string logString;
    string stackTrace;
    LogType logType;

    public static int ccc = 0;
    private int curIndex = 0;
    public DebugLog(string logString, string stackTrace, LogType logType)
    {
        this.logString = logString;
        this.stackTrace = stackTrace;
        this.logType = logType;
        curIndex = ccc;
        ccc++;
    }

    public override string ToString()
    {

        if (this.logString.Length > 300)
        {
            return this.logString.Substring(0, Mathf.Min(this.logString.Length - 1, 300)) + " --> " + curIndex;
        }
        else
        {
            return this.logString + " --> " + curIndex;
        }

    }
}
