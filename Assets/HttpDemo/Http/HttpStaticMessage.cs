using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HttpStaticMessage 
{

    public static void AutoSendHttpVerson(string ver, bool isDebug, UnityAction<System.Object> CallBack)
    {
        HttpMsgManager.GetInstance().SendMsg(new Dictionary<string, string>() { { "ver" , ver}, { "debug", isDebug? 1.ToString(): 0.ToString() } }, CallBack);
    }

    public static string GetUID()
    {
        return SystemInfo.deviceUniqueIdentifier;//设备唯一标识符  MD5加密的
    }
}
