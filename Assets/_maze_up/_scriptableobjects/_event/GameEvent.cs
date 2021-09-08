using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/Event", order = 100)]
public class GameEvent : ScriptableObject
{
    public List<GameEventlistener> m_listerners = new List<GameEventlistener>();


    public void _Raise()
    {
        foreach (GameEventlistener item in m_listerners)
        {
            if (item!=null)
            {
                item._InvokeEvent();
            }
        }
    }

    public void _RegisterEvent(GameEventlistener m_game_event)
    {
        if (!m_listerners.Contains(m_game_event))
        {
            m_listerners.Add(m_game_event);
        }
    }


    public void _DeRegisterEvent(GameEventlistener m_game_event)
    {
        if (m_listerners.Contains(m_game_event))
        {
            m_listerners.Remove(m_game_event);
        }
    }

}
