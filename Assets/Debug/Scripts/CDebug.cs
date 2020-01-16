using UnityEngine;
using System.Runtime.InteropServices;
using System;

/// <summary>CDebug 类</summary>
public class CDebug
{
    /// <summary>是否为调试模式</summary>
	public static bool IsDebug = true;

    /// <summary>打印普通日志</summary>
    public static void Log(string log, UnityEngine.Object logObject = null)
    {
        if (!IsDebug)
        {
            return;
        }

        if (logObject != null)
            Debug.Log(log);
        else
            Debug.Log(log, logObject);
    }

    public static void LogObj(System.Object x)
    {
        Debug.Log(x.GetType().GetProperties().Length + " ");
        foreach (System.Reflection.PropertyInfo p in x.GetType().GetProperties())
        {
            var xx = p.Name;
            var yy = p.GetValue(x, null);
            Debug.Log(xx + " ->" + yy);
        }
    }
    /// <summary>打印错误日志</summary>
    public static void LogError(string logError, UnityEngine.Object logObject = null)
    {
        if (!IsDebug)
        {
            return;
        }

        if (logObject != null)
            Debug.LogError(logError);
        else
            Debug.LogError(logError, logObject);
    }

    /// <summary>打印警告日志</summary>
    public static void LogWarning(string logWarning, UnityEngine.Object logObject = null)
    {
        if (!IsDebug)
        {
            return;
        }

        if (logObject != null)
            Debug.LogWarning(logWarning);
        else
            Debug.LogWarning(logWarning, logObject);
    }

    /// <summary>打印异常日志</summary>
    public static void LogException(System.Exception exception, UnityEngine.Object logObject = null)
    {
        if (!IsDebug)
        {
            return;
        }

        if (logObject != null)
            Debug.LogException(exception);
        else
            Debug.LogException(exception, logObject);
    }

    /// <summary>打印某个对象的内存地址</summary>
    public static void LogMemory(System.Object debugObject, string log = "")
    {
        if (!IsDebug)
        {
            return;
        }

        GCHandle gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(debugObject, GCHandleType.Pinned);
        IntPtr addr = gcHandle.AddrOfPinnedObject();
        CDebug.Log(log + "0x" + addr.ToString());
    }
}