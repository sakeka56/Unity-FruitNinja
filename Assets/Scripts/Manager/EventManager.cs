using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{


    // 存储事件：键为事件名，值为委托（可包含多个方法）
    private Dictionary<string, Action> events = new Dictionary<string, Action>();

    private Dictionary<string,Action<object>> onePEvents = new Dictionary<string,Action<object>>();

    // 注册事件（若事件名已存在则跳过）
    public void Register(string eventName, Action action)
    {
        if (!events.ContainsKey(eventName))
        {
            events[eventName] = action;
        }
    }

    // 添加事件监听（事件不存在则自动创建）
    public void AddListener(string eventName, Action action)
    {
        if (!events.ContainsKey(eventName))
        {
            events[eventName] = null;
        }
        events[eventName] += action;
    }

    // 移除事件监听
    public void RemoveListener(string eventName, Action action)
    {
        if (events.TryGetValue(eventName, out Action eventAction))
        {
            eventAction -= action;
            // 若委托为空，移除事件节省内存
            if (eventAction == null)
            {
                events.Remove(eventName);
            }
        }
    }

    // 触发事件
    public void TriggerEvent(string eventName)
    {
        if (events.TryGetValue(eventName, out Action eventAction) && eventAction != null)
        {
            eventAction.Invoke();
        }
    }



    public void Register(string eventName, Action<object> action)
    {
        if (!onePEvents.ContainsKey(eventName))
        {
            onePEvents[eventName] = action;
        }
    }

    public void AddListener(string eventName, Action<object> action)
    {
        if (!onePEvents.ContainsKey(eventName))
        {
            onePEvents[eventName] = null;
        }
        onePEvents[eventName] += action;
    }

    public void RemoveListener(string eventName, Action<object> action)
    {
        if (onePEvents.TryGetValue(eventName, out Action<object> eventAction))
        {
            eventAction -= action;
            // 若委托为空，移除事件节省内存
            if (eventAction == null)
            {
                onePEvents.Remove(eventName);
            }
        }
    }

    public void TriggerEvent(string eventName,object ob)
    {
        if (onePEvents.TryGetValue(eventName, out Action<object> eventAction) && eventAction != null)
        {
            eventAction.Invoke(ob);
        }
    }


}