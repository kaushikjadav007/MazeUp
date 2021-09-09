using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public GameObject m_coin;
    public Transform m_text;
    [Space]
    public Valueholder m_value_holder;

    private float m_timer=0f;

    public void _DoAnimation()
    {
        Debug.Log("DoingAnimation");
        m_coin.SetActive(false);
        StartCoroutine(_TextEffect());
    }

    IEnumerator _TextEffect()
    {
        m_text.gameObject.SetActive(true);

        m_value_holder.m_score += 10;
        m_value_holder._AddScore();

        while (m_timer<1.5f)
        {
            m_timer += Time.deltaTime;
            m_text.transform.localPosition += Vector3.up *0.01f;
            yield return null;
        }

        m_text.transform.localPosition = Vector3.zero;
        m_text.gameObject.SetActive(false);
        Debug.Log("Done");
    }

    public void _Reset()
    {
        m_coin.SetActive(true);
        m_timer = 0f;
    }

    private void OnTriggerEnter(Collider m_col)
    {
        if (m_col.CompareTag("Player"))
        {
            _DoAnimation();
        }
    }

}
