using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class MsgResponseData
{
    /// <summary>响应获得内容</summary>
    private string mResponstContent = string.Empty;
    /// <summary>服务器时间</summary>
    private string mServerTime = string.Empty;
    /// <summary>请求用时</summary>
    private string mExtTime = string.Empty;
    /// <summary>网络相应的状态值，非0为异常</summary>
    private int mResponseStatu;
    /// <summary>网络相应出现异常时附带的消息</summary>
    private string mResponseMsg;
    /// <summary>消息体的Json对象</summary>
    private JsonData mJsonData = null;

    public MsgResponseData(string data)
    {
        mResponstContent = data;

        if (mResponstContent == "")
        {
            mResponseStatu = -99999;
            //网络请求相应的状态
            mResponseMsg = "网络连接不可用";
            return;
        }

        //创建json对象
        mJsonData = LitJson.JsonMapper.ToObject(mResponstContent);
    }

}
