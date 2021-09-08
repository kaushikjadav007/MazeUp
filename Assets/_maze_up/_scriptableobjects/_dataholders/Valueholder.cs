using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ValueHolder", menuName = "ScriptableObjects/ValueHolder", order = 100)]
public class Valueholder : ScriptableObject
{
    public Vector3 m_player_position;
    [Space]
    public int m_collected_coin_count;



}
