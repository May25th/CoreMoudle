using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HttpMsg{
	private string link;//链接
	private WWW mHttp3W;
    private HttpType mType;//通信方式
	private MsgRequestData msg;//参数
    private MsgResponseData resData;//返回值
    private UnityAction<System.Object> CallBack;
    private UnityAction<HttpMsg> ResetBack;
    private static Dictionary<string, string> MsgHeaders = new Dictionary<string, string>() { { "Content-Type", "application/x-www-form-urlencoded" } };

    public HttpMsg()
	{
		
	}

    private float startTime;
	public void SendMsg(Dictionary<string, string> dic, UnityAction<System.Object> CallBack, UnityAction<HttpMsg> ResetBack)
	{
        msg = new MsgRequestData(dic);
        this.CallBack = CallBack;
        this.ResetBack = ResetBack;
        startTime = Time.realtimeSinceStartup;
    }

    public IEnumerator Send()
    {
        if (mType == HttpType.Post)
        {
            mHttp3W = new WWW(URL, System.Text.UTF8Encoding.UTF8.GetBytes(msg.RequestParamContent), MsgHeaders);
        }
        else
        {
            mHttp3W = new WWW(URLAndParamsForGet);
        }
        CDebug.Log(mHttp3W.url  + "   "  +  (Time.realtimeSinceStartup  - startTime));
        yield return mHttp3W;//等待Web服务器的反应
        if (mHttp3W.error != null)
        {
            Debug.Log(mHttp3W.error);
            yield return null;
        }
        Debug.Log(mHttp3W.text);
        if (CallBack != null)
        {
            CallBack(mHttp3W.text);
        }
        if (ResetBack != null)
        {
            ResetBack(this);
        }
    }

    private string URL
    {
        get { return "http://bi.bellcat.cn/server/checkVer/"; }
    }

    public string URLAndParamsForGet
    {
        get
        {
            return "http://bi.bellcat.cn/server/checkVer/" + "?" + msg.RequestParamContent;
        }
    }

    public bool CheckDone
	{
		get{ return mHttp3W.isDone;}
	}

    public enum HttpType
    {
        Get,
        Post,
    }
}
