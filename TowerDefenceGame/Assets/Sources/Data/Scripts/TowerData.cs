using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tower Data", menuName = "Data/TowerData")]

public class TowerData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public float MaxHealth;
    public float BaseDamage;
    public float AttackRate;
    public GameObject TowerPrefab;
}
