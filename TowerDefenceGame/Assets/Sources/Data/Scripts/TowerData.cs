using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "Data/TowerData")]
public class TowerData : ScriptableObject
{
    public TowerType TypeOfTower;


    [Header("Resources")]
    public Sprite Icon;
    public GameObject TowerPrefab;

    public int UpgradeCount;
    public List<TowerLevelInfo> UpdageInfo;

    [System.Serializable]
    public class TowerLevelInfo
    {
        public string Name;
        public float BaseDamage;
        public float SellPrice;
        public float UpgradePrice;
        public float AttackRate;
        public float AttackRadius;
        public GameObject Prefab;
    }

    public enum TowerType
    {
        MachineGun = 0,
        Missile = 1,
        Laser = 2
    }
}
