using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var globabEventListener in listeners)
        {
            globabEventListener.RaiseEvent();
        }
    }

    public void Register(GameEventListener listener) => listeners.Add(listener);
    public void Deregister(GameEventListener listener) => listeners.Remove(listener);
}
