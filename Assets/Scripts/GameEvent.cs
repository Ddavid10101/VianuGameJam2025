
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Scriptable Objects/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> Listeners = new List<GameEventListener>();

    public void TriggerEvent()
    {
        for( int i = Listeners.Count- 1; i>= 0; --i)
        {
            Listeners[i].OnEventTriggered();
        }
    }

    public void AddListener(GameEventListener Listener)
    {
        Listeners.Add(Listener);
    }

    public void RemoveListener(GameEventListener Listener) 
    {
        Listeners.Remove(Listener); 
    }
}
