using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent")]
public class GameEvent : ScriptableObject
{ 
   public List<GameEventListener> listerners = new List<GameEventListener>();

    // Raise event through different methods

    public void Raise(Component sender, object data)
    {
        for (int i = 0; i < listerners.Count; i++)
        {
            listerners[i].OnEventRaised(sender, data);
        }
    }

    // Manage Listeners

    public void RegisterListener(GameEventListener listener)
    {
        if (!listerners.Contains(listener))
        {
            listerners.Add(listener);
        }
           
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (listerners.Contains(listener))
        {
            listerners.Remove(listener);
        }
    }



}
