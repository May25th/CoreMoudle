using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HttpTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HttpStaticMessage.AutoSendHttpVerson("0.2", true, CallBack);
        }
    }

    private void CallBack(System.Object datas)
    {
        CDebug.Log("CallBack");
    }
}
