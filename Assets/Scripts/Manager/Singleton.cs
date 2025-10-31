using System;
using Unity.VisualScripting;
using UnityEngine;



/// <summary>
/// 继承自MonoBehavior的单例
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : class
{
    /// <summary>
    /// 私有私立
    /// </summary>
    protected static T instance;

    /// <summary>
    /// 公共实例
    /// </summary>
    public static T Instance
    {
        get 
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                Debug.LogWarning($"{typeof(T)} 继承了单例，但instance为空");
                return null;

            }
            
        }
    }

    /// <summary>
    /// 如果已存在，是否要用新实例覆盖旧实例
    /// </summary>
    public bool isOverInstance = false;

    /// <summary>
    /// 在场景转换时销毁
    /// </summary>
    public bool OnSceneChangedDestroy = true;

    /// <summary>
    /// 在Awake中调用Init方法
    /// </summary>
    public bool OnAwakeInit = true;




    private void Awake()
    {
        if (instance == null)
        {//未实例化
            instance = this as T;
            Debug.Log(this as T + "Awake");
        }
        else
        {
            if (isOverInstance)
            {//是否覆盖旧实例
                Debug.Log($"{typeof(T).Name}： 创建新实例覆盖旧实例");
                instance = this as T;
            }
            else
            {
                Debug.LogWarning($"{typeof(T).Name} 实例已存在");
            }

        }

        //如果为True则销毁
        if (!OnSceneChangedDestroy) { DontDestroyOnLoad(this); };

        //初始化
        if(OnAwakeInit) Init();
    }

    /// <summary>
    /// 在Awake时进行调用
    /// </summary>
    protected virtual void Init()
    {

    }


}
