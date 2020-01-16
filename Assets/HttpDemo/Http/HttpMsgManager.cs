using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HttpMsgManager:MonoBehaviour{

    private List<HttpMsg> waittingList = new List<HttpMsg>();//等待发送的 发送后放入处理队列
	private List<HttpMsg> cacheList = new List<HttpMsg>();//空闲状态的  取出后放入等待队列
	private List<HttpMsg> responseList = new List<HttpMsg>();//等待处理请求的 处理完后放入空闲队列

    #region 单利
    private static HttpMsgManager Instance;
    /// <summary>单利函数</summary>
    public static HttpMsgManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject HttpMsgManagerObj = new GameObject();
            Instance = HttpMsgManagerObj.AddComponent<HttpMsgManager>();
            DontDestroyOnLoad(HttpMsgManagerObj);
        }
        return Instance;
    }
    #endregion

    public void SendMsg(Dictionary<string, string> data, UnityAction<System.Object> action)
    {
        OnGetHttpMsg().SendMsg(data,action, ResetMsg);
    }

    /// <summary>得到一个HttpMsg对象</summary>
    private HttpMsg OnGetHttpMsg()
    {
        HttpMsg httpMsg = null;
        if (cacheList.Count > 0)
        {
            httpMsg = cacheList[0];
            cacheList.RemoveAt(0);
        }

        if (httpMsg == null)
        {
            httpMsg = new HttpMsg();
        }
        waittingList.Add(httpMsg);
        return httpMsg;
    }

	private int index;
    private void LateUpdate()
    {
        //检查需要发送的
        if (waittingList.Count > 0)
        {
            for (index = waittingList.Count - 1; index >= 0; index--)
            {
                StartCoroutine(waittingList[index].Send());
            }
            responseList.InsertRange(0, waittingList);
            waittingList.Clear();
        }
    }

    private void ResetMsg(HttpMsg msg)
    {
        if(responseList.Remove(msg))
        {
            cacheList.Add(msg);
        }
    }
}
