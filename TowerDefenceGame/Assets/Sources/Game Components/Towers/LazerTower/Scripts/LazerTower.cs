using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTower : BaseTower, IUpgradable
{
    public void Upgrade()
    {
        Level++;
        TowerData.TowerLevelInfo newLevelInfo = TowerData.UpdageInfo[Level - 1];
        UpdateStats();
        ChangeLevelModel();
    }

    
}
