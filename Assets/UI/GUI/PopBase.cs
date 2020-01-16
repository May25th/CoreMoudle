using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pop弹出框的基类
public class PopBase : MonoBehaviour
{
    //弹出框的动画特效
    private Animator mAni;
    //同一类弹出框 同一时间只能出现一个
    private PopType popType { get { return PopType.Login; } }


    protected virtual void Awake()
    {
        mAni = this.GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        InitInfo();
        if(mAni)
            mAni.SetBool("Play", true);
    }

    protected virtual void InitInfo()
    {

    }

    public void Hide()
    {
        if (mAni)
        {
            mAni.SetBool("Play", false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void LateUpdate()
    {

    }
}
