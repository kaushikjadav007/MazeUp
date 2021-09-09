using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChunks : MonoBehaviour
{
    public GameObject m_last_platform;
    [Space]
    public List<Coins> m_coins;
    [Header("ScriptableObject holder")]
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
        if (transform.position.y+10f<m_value_holder.m_player_position.y)
        {
            if (m_coins.Count>0)
            {
                for (int i = 0; i < m_coins.Count; i++)
                {
                    m_coins[i]._Reset();
                }
            }

            gameObject.SetActive(false);
        }
    }
}
