using System.Collections;
using System.Collections.Generic;
using System.Text;

//需要发送的数据对象
public class MsgRequestData{

	private Dictionary<string, string> param_data = new Dictionary<string, string>();
	/// <summary>包含url和参数的字符串</summary>
	private string mRquestParamConetent;

	public MsgRequestData(Dictionary<string, string> data)
	{
		param_data = data;
	}
	/// <summary>请求的参数体</summary>
	public string RequestParamContent
	{
		get
		{
			if (mRquestParamConetent == null)
			{
				StringBuilder strContent = new StringBuilder();
				bool isFirstStr = true;
				foreach (KeyValuePair<string, string> kvp in param_data)
				{
					this.ParamAddStringBuilder (strContent, kvp.Key, kvp.Value, !isFirstStr);
					if (isFirstStr) {
						isFirstStr = false;
					}
				}
				mRquestParamConetent = strContent.ToString();
			}
			//返回
			return mRquestParamConetent;
		}
	}

	/// <summary>参数添加到消息体内</summary>
	private void ParamAddStringBuilder(StringBuilder strContent, string key, string value, bool isApart = true)
	{
		if (isApart)
		{
			strContent.Append("&");
		}
		strContent.Append(key);
		strContent.Append("=");
		strContent.Append(value);
	}
}
