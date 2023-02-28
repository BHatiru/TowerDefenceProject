using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
   [SerializeField] private TowerLibrary _towerLibrary;
   [SerializeField] private SelectionSystem _selectionSystem;
   [SerializeField] private TowerUpgradeSystem _upgradeSystem;

   private Dictionary<TowerData.TowerType, TowerData> _towerDataMap;

   private void Awake()
   {
      
      _towerDataMap = new Dictionary<TowerData.TowerType, TowerData>();
      foreach(TowerData towerData in _towerLibrary.Library){
         _towerDataMap.Add(towerData.TypeOfTower, towerData);
      }
   }
   public void BuildTower(TowerData.TowerType towerType){

      IMouseInteractable currentSelected = _selectionSystem.CurrentSelected;

      if(currentSelected is TowerCell cell){
         if(cell.IsCellUsed()){
            return;
         }
         GameObject prefab = _towerDataMap[towerType].TowerPrefab;
         Vector3 position = _selectionSystem.SelectedObjectPosition;
         GameObject tower = Instantiate(prefab, position, Quaternion.identity);
         BaseTower baseTower = tower.GetComponent<BaseTower>();

         baseTower?.Initialize(_towerDataMap[towerType]);

         
         StartCoroutine(BuildTowerInTime(tower, 2f));
         _upgradeSystem.RegisterTower(currentSelected, baseTower);
         cell.UseCell();
         
      }
      
   }

   private IEnumerator BuildTowerInTime(GameObject tower, float duration){

      float startTime = Time.time;
      float endTime = startTime + duration;

      float startSize = 0.05f;
      float endSize = tower.transform.localScale.x;

      while(Time.time < endTime){
         float lerp = (Time.time - startTime) / duration;
         float size = Mathf.Lerp(startSize, endSize, lerp);
         tower.transform.localScale = Vector3.one * size;
         yield return new WaitForEndOfFrame();
      }

      tower.transform.localScale = Vector3.one * endSize;
   }
}
