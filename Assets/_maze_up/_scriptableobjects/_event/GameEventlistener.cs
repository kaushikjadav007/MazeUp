using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventlistener : MonoBehaviour
{
    public GameEvent m_game_event;
    [Space]
    public UnityEvent m_simple_event;


    private void OnEnable()
    {
        if (m_game_event == null)
        {
            Debug.LogError("Null Game Event " + gameObject.name);
            return;
        }

        m_game_event._RegisterEvent(this);
    }

    private void OnDisable()
    {
        if (m_game_event == null)
        {
            Debug.LogError("Null Game Event " + gameObject.name);
            return;
        }

        m_game_event._DeRegisterEvent(this);
    }

    public void _InvokeEvent()
    {
        if (m_simple_event != null)
        {
            m_simple_event.Invoke();
        }
    }
}
