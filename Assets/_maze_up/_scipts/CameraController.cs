using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_target;
    [Space]
    public float m_damping= 5.0f;
    [Space]
    public Vector3 m_offset;

    private float m_wanted_y_pos;

    // Update is called once per frame
    void LateUpdate()
    {

        if (m_target==null)
        {
            return;
        }

        m_wanted_y_pos = m_target.transform.eulerAngles.y;

        transform.position = Vector3.Lerp(transform.position, m_target.position+m_offset, Time.deltaTime * m_damping);

        transform.LookAt(m_target.transform);
    }

    public void _OnGameOver()
    {
        m_target = null;
    }
}
