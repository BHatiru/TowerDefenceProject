using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIHandler : MonoBehaviour
{
    [SerializeField] private BuildTowerPanel _buildTowerPanel;
    // Start is called before the first frame update
    private void Start()
    {
        SceneEventSystem.Instance.CellSelected += OnCellSelected;
        SceneEventSystem.Instance.CellDeselected += OnCellDeselected;
    }

     private void OnCellDeselected(TowerCell towerCell)
    {
         _buildTowerPanel.Hide();
    }

    private void OnCellSelected(TowerCell towerCell)
    {
       
        _buildTowerPanel.Show();
    }
}
