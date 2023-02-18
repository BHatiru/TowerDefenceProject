using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventSystem : MonoBehaviour
{
    public static SceneEventSystem Instance { get; private set; }

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }  

    public delegate void CellEvent(TowerCell towerCell);

    public event CellEvent CellSelected;
    public event CellEvent CellDeselected;

    public void NotifyCellSelected(TowerCell towerCell)
    {
        CellSelected?.Invoke(towerCell);
    }

    public void NotifyCellDeselected(TowerCell towerCell)
    {
        CellDeselected?.Invoke(towerCell);
    }
}
