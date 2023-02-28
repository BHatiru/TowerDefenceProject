using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    protected string Name;
    protected float BaseDamage;
    protected float SellPrice;
    protected float BuildPrice;
    protected float AttackRate;
    protected float AttackRadius;
    protected Vector3 TowerPos;

    protected int Level;
    [SerializeField] protected TowerData TowerData;

    [Header("Level Objects")]
    [SerializeField] private GameObject[] _towerLevels;
    [SerializeField] protected Transform _rotateElementHorizontal;
    [SerializeField] protected Transform _rotateElementVertical;

    protected List<BaseEnemy> Enemies;
    protected List<BaseEnemy> EnemiesInRadius;
    public void Initialize(TowerData towerData, List<BaseEnemy> enemies)
    {
        Level = 0;
        TowerData = towerData;
        Enemies = enemies;
        EnemiesInRadius = new ();
        TowerPos = transform.position;
        UpdateStats();
    }
    private void FixedUpdate()
    {
        FindEnemies();
    }

    protected void FindEnemies()
    {
        EnemiesInRadius.Clear();
        for(int i=0;i<Enemies.Count;i++){
            
            float distance = Vector3.Distance(TowerPos, Enemies[i].transform.position);
            if(distance <= AttackRadius){
                EnemiesInRadius.Add(Enemies[i]);
            }
        }
        
    }

    protected void UpdateStats()
    {
        TowerData.TowerLevelInfo levelInfo  = TowerData.UpdageInfo[Level];
        Name = levelInfo.Name;
        BaseDamage = levelInfo.BaseDamage;
        SellPrice = levelInfo.SellPrice;
        AttackRate = levelInfo.AttackRate;
        AttackRadius = levelInfo.AttackRadius;
        BuildPrice = levelInfo.UpgradePrice;
    }

    protected void ChangeLevelModel(){
        for (int i = 0; i < _towerLevels.Length; i++){
            bool isRightLevel = i == Level;
            _towerLevels[i].SetActive(isRightLevel);
        }
    }
}
