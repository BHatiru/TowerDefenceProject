using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected float BaseDamage;
    [SerializeField] protected float SellPrice;
    [SerializeField] protected float BuildPrice;
    [SerializeField] protected float AttackRate;
    [SerializeField] protected float AttackRange;

    [SerializeField] protected int Level;
    [SerializeField] protected TowerData TowerData;

    [Header("Tower Levels")]
    [SerializeField] private GameObject[] _towerLevels;

    public void Initialize(TowerData towerData)
    {
        Level = 0;
        TowerData = towerData;
        UpdateStats();
    }

    protected void FindEnemies()
    {

    }

    protected void UpdateStats()
    {
        TowerData.TowerLevelInfo levelInfo  = TowerData.UpdageInfo[Level];
        Name = levelInfo.Name;
        BaseDamage = levelInfo.BaseDamage;
        SellPrice = levelInfo.SellPrice;
        AttackRate = levelInfo.AttackRate;
        AttackRange = levelInfo.AttackRange;
        BuildPrice = levelInfo.UpgradePrice;
    }

    protected void ChangeLevelModel(){
        for (int i = 0; i < _towerLevels.Length; i++){
            bool isRightLevel = i == Level;
            _towerLevels[i].SetActive(isRightLevel);
        }
    }
}
