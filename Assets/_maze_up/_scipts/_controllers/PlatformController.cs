using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> m_platform;

    [Header("Pooled Platforms")]
    public List<_PooledPlatforms> m_pooled_platforms;
    //[Space]
    //public int m_test_platform_no;
    //public bool m_test;

    [Header("Platform Genration values")]
    public Vector3 m_pos;

    [Header("Script holder")]
    public ScriptRefrenceHolder m_script_ref;

    private GameObject m_temp_go;
    private GameObject m_genrated_obj;
    [Space]
    public PlatformChunks m_last_chunk;

    public int m_platform_disable_count;
    private int m_direction_decider;
    private int m_count;

    private int m_aaa;
    private _PooledPlatforms m_temp_pooled_platform;

    private void Awake()
    {
        m_script_ref.m_platform_controller = GetComponent<PlatformController>();
    }

    private void Start()
    {

        m_count = m_platform.Count;

        for (int i = 0; i < 3; i++)
        {
            //Initial Setup
            m_direction_decider = Random.Range(0, 2);
            _Genrate();
        }
    }

    public void _GenrateNewPlatform()
    {
        //Count Next platform position
        m_direction_decider = Random.Range(0, 2);
        _Genrate();
    }


   void _Genrate()
    {
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

        //FOR TESTING

        //if (m_test)
        //{
        //    m_temp_go = _GetPlatform(m_test_platform_no);
        //}
        //else
        //{
        //    m_temp_go = _GetPlatform(Random.Range(0,m_count));
        //}

        m_temp_go = _GetPlatform(Random.Range(0, m_count));
        m_temp_go.gameObject.SetActive(true);

        m_last_chunk = m_temp_go.GetComponent<PlatformChunks>();
    }

    GameObject _GetPlatform(int m_id)
    {    
        if (m_pooled_platforms.Count>0)
        {
            int m_a = m_pooled_platforms.Count;

            //Check If Platform is available
            for (int i = 0; i < m_a; i++)
            {
                if (m_pooled_platforms[i].m_platform_id==m_id && !m_pooled_platforms[i].m_platform_obj.activeSelf)
                {
                    m_genrated_obj = m_pooled_platforms[i].m_platform_obj;
                    m_genrated_obj.transform.SetPositionAndRotation(m_pos, Quaternion.identity);
                   
                    return m_genrated_obj;
                }
            }

        }

        //Genrate new platform
        m_genrated_obj = Instantiate(m_platform[m_id], m_pos, Quaternion.identity);

#if UNITY_EDITOR
        m_aaa++;
        m_genrated_obj.name = m_aaa.ToString();
#endif

        m_temp_pooled_platform = new _PooledPlatforms();
        m_temp_pooled_platform.m_platform_obj = m_genrated_obj;
        m_temp_pooled_platform.m_platform_id = m_id;

        m_pooled_platforms.Add(m_temp_pooled_platform);
        return m_genrated_obj;
    }


}
[System.Serializable]
public class _PooledPlatforms
{
    public GameObject m_platform_obj;
    public int m_platform_id;
}
