using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCell : MonoBehaviour, IMouseInteractable
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _onHoverMaterial;
    [SerializeField] private Material _onSelectMaterial;

    private MeshRenderer _meshRenderer;
    private bool _selected;

    private void Awake(){
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void OnClick()
    {
        if(_selected == false)
        
        _meshRenderer.material = _onSelectMaterial;
        _selected = true;
    }

    public void OnHoverEnter()
    {
        if(_selected == false){
          
        _meshRenderer.material = _onHoverMaterial;
        }
        
    }

    public void OnHoverExit()
    {
        if(_selected == false){
        
        _meshRenderer.material = _defaultMaterial;
        }
    }

    public void Deselect(){
        _selected = false;
        _meshRenderer.material = _defaultMaterial;
    }
}
