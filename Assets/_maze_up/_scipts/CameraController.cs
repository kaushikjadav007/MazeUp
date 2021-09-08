using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform m_target;
    [Space]
    public float m_damping;
    [Space]
    public Vector3 m_offset;

    void Update()
    {

        if (m_target == null)
        {
            return;
        }

		transform.position = Vector3.Lerp(transform.position, m_target.position + m_offset, m_damping);

        transform.LookAt(m_target.transform);
    }

    public void _OnGameOver()
    {
        m_target = null;
    }
}
