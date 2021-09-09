using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public delegate void _CheckForDisabledPlatform();
    public static event _CheckForDisabledPlatform e_check_for_disable_platform;

    [Header("Scriptable Object")]
    public ScriptRefrenceHolder m_script_ref;
    private void Awake()
    {
        m_script_ref.m_event_controller = GetComponent<EventController>();
    }

    public  void _NotifyOnPlatformDisable()
    {
        if (e_check_for_disable_platform != null)
        {
            e_check_for_disable_platform();
        }
    }
}
