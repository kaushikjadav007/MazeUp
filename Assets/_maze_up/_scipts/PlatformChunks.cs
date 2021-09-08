using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChunks : MonoBehaviour
{
    public GameObject m_last_platform;
    [Space]
    public Valueholder m_value_holder;


    private void OnEnable()
    {
        EventController.e_check_for_disable_platform += _DisableCheck;    
    }

    private void OnDisable()
    {
        EventController.e_check_for_disable_platform -= _DisableCheck;
    }


    public void _DisableCheck()
    {

        if (transform.position.y+5f<m_value_holder.m_player_position.y)
        {
            Debug.Log("DisableCheck");
            gameObject.SetActive(false);
        }
    }


}
