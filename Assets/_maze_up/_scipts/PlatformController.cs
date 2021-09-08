using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> m_platform;

    [Header("Platform Genration values")]
    public Vector3 m_pos;

    [Header("Script holder")]
    public ScriptRefrenceHolder m_script_ref;


    private GameObject m_temp_go;

    [Space]
    public int m_initial_direction;
    private int m_direction_decider;


    [Space]
    public PlatformChunks m_last_chunk;

    private void Awake()
    {
        m_script_ref.m_platform_controller = GetComponent<PlatformController>();
    }

    private void Start()
    {
        //Initial Setup
        m_initial_direction = Random.Range(0, 2);
        m_direction_decider = m_initial_direction;
        _Genrate();

    }

    public void _GenrateNewPlatform()
    {
        //Count Next platform position

        m_direction_decider = Random.Range(0, 2);
        _Genrate();
    }


   void _Genrate()
    {
        Debug.Log("gerated");

        m_pos = m_last_chunk.m_last_platform.transform.position;

        switch (m_direction_decider)
        {
            case 0:
                m_pos.x += 1f;
                break;
            case 1:
                m_pos.z += 1f;
                break;
        }

        m_pos.y += 0.5f;

        m_temp_go = Instantiate(m_platform[Random.Range(0,m_platform.Count)],m_pos, Quaternion.identity);
        m_last_chunk = m_temp_go.GetComponent<PlatformChunks>();

        //Disable older platform
        m_script_ref.m_event_controller._NotifyOnPlatformDisable();
    }
}
