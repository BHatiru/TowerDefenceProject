using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class BuildTowerPanel : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private TowerLibrary _towerLibrary;
    [SerializeField] private BuildSystem _buildSystem;
    private void Start()
    {
        foreach (var towerData in _towerLibrary.Library){
            GameObject newButton = Instantiate(_buttonPrefab);
            newButton.transform.SetParent(transform);
            Image image = newButton.GetComponent<Image>();
            image.sprite = towerData.Icon;

            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            text.text = towerData.Name;

            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(BuildCannonTower);
        }
    }

    private void BuildCannonTower()
    {
        _buildSystem.BuildTower(_towerLibrary.Library[0], new Vector3(19.733f, 1.2f, -27.16f));
    }

}
