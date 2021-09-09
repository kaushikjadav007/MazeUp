using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform m_target;
    public Transform m_star_effect;
    [Space]
    public Vector3 m_offset;
    [Space]
    public float m_smooth_speed = 0.3f;
    [Space]
    public float m_speed;

    private Vector3 m_velocity = Vector3.zero;

    private Vector3 m_target_pos;
    private Quaternion m_target_rotation;
    private Vector3 m_temp_pos;

    private void FixedUpdate()
    {

        if (m_target==null)
        {
            return;
        }

        m_target_pos = m_target.position + m_offset;

        transform.position = Vector3.SmoothDamp(transform.position, m_target_pos, ref m_velocity, m_smooth_speed);

        m_target_rotation = Quaternion.LookRotation(m_target.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, m_target_rotation, m_speed * Time.deltaTime);
        //m_temp_pos = m_star_effect.position;
        //m_temp_pos.y = transform.position.y;
        //m_star_effect.position = m_temp_pos;


    }
    public void _OnGameOver()
    {
        m_target = null;
    }
}
