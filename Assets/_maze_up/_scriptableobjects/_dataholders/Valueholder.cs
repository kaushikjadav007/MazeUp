using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "ValueHolder", menuName = "ScriptableObjects/ValueHolder", order = 100)]
public class Valueholder : ScriptableObject
{
    public Vector3 m_player_position;
    [Space]
    public int m_score;
    [Space]
    public TextMeshProUGUI m_score_text;


    public void _AddScore()
    {
        if (m_score_text!=null)
        {
          m_score_text.text = m_score.ToString();
        }
    }
}
