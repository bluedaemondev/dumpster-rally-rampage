using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void EventReceiver(params object[] parameterContainer);

    static Dictionary<string, EventReceiver> _events;

    public static void SubscribeToEvent(string eventType, EventReceiver listener)
    {
        if (_events == null) 
            _events = new Dictionary<string, EventReceiver>(); 

        if (!_events.ContainsKey(eventType)) 
        {
            _events.Add(eventType, null); 
        }

        _events[eventType] += listener; 
    }

    public static void Unsubscribe(string eventType, EventReceiver listener)
    {
        if (_events != null) 
        {
            if (_events.ContainsKey(eventType)) 
            {
                _events[eventType] -= listener; 
            }
        }
    }

    public static void ExecuteEvent(string eventType, params object[] parameters)
    {
        if (_events == null) 
        {
            Debug.Log("No events subscribed");
            return; 
        }

        if (_events.ContainsKey(eventType))
        {
            if (_events[eventType] != null) 
            {
                _events[eventType](parameters); 
            }
        }
    }

    public static void ExecuteEvent(string eventType)
    {
        ExecuteEvent(eventType, null);
    }
}
