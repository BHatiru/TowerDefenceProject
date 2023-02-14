using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
   public void BuildTower(TowerData towerData, Vector3 position){
        Instantiate(towerData.TowerPrefab, position, Quaternion.identity);
   }
}
