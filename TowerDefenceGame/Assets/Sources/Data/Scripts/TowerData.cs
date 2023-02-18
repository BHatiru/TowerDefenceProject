using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tower Data", menuName = "Data/TowerData")]

public class TowerData : ScriptableObject
{
    public TowerType TypeOfTower;

    [Header("Settings")]
    public string Name;
    public float BaseDamage;
    public float MaxHealth;
    public float AttackRate;

    [Header("Resources")]
    public Sprite Icon;
    public GameObject TowerPrefab;

    public enum TowerType
    {
        CannonTower = 0,
        BowTower = 1
    }
}
