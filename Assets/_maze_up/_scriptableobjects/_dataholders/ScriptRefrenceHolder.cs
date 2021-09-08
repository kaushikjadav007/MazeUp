using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScriptRefrence",menuName = "ScriptableObjects/ScriptRefrence", order = 100)]
public class ScriptRefrenceHolder : ScriptableObject
{
    public PlatformController m_platform_controller;
    public PlayerController m_player_Controller;
    public UiController m_ui_controller;
    public EventController m_event_controller;
}
