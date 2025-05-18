using System;
using System.Collections.Generic;

public static class EventBus
{
    public delegate void EventHandler<T>(T eventData);
    public delegate void EventHandler();

    public static Dictionary<Type, List<Delegate>> eventDictionary = new Dictionary<Type, List<Delegate>>();

    public static void Subscribe<T>(EventHandler<T> handler)
    {
        if (!eventDictionary.ContainsKey(typeof(T)))
        {
            eventDictionary[typeof(T)] = new List<Delegate>();
        }

        eventDictionary[typeof(T)].Add(handler);
    }

    public static void Unsubscribe<T>(EventHandler<T> handler)
    {
        if (eventDictionary.ContainsKey(typeof(T)))
        {
            eventDictionary[typeof(T)].Remove(handler);
            if (eventDictionary[typeof(T)].Count == 0)
            {
                eventDictionary.Remove(typeof(T));
            }
        }
    }

    public static void Publish<T>(T eventData)
    {
        if (eventDictionary.ContainsKey(typeof(T)))
        {
            foreach (var handler in eventDictionary[typeof(T)])
            {
                ((EventHandler<T>)handler)(eventData);
            }
        }
    }
}
