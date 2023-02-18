using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSystem : MonoBehaviour
{
    private const float MAX_RANGE = 50f;
    [SerializeField] private LayerMask _interactableObjectMask;
    [SerializeField] private Camera _camera;

    public IMouseInteractable CurrentSelected => _currentSelected;
    private IMouseInteractable _currentInteractable;
    private IMouseInteractable _currentSelected;
    public Vector3 SelectedObjectPosition => _currentSelected == null ? Vector3.zero : _currentSelected.GetPosition();
        
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        SelectionUpdate();
    }

    private void SelectionUpdate(){
        if (Input.GetMouseButtonDown(0))
        {

            if (_currentInteractable != null)
            {

                if (_currentSelected != null && _currentSelected != _currentInteractable)
                {
                    _currentSelected.Deselect();
                }

                _currentSelected = _currentInteractable;
                _currentSelected.OnClick();
            }
            else
            {
                if (_currentSelected != null)
                {
                    _currentSelected.Deselect();
                }
            }
        }
    }

    
    private void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        bool hitSomething = Physics.Raycast(ray, out RaycastHit hit, MAX_RANGE, _interactableObjectMask);

        if (!hitSomething)
        {
            ClearInteractable();
            return;
        }



        IMouseInteractable interactable = hit.collider.gameObject.GetComponent<IMouseInteractable>();

        if (interactable == null)
        {
            ClearInteractable();
            return;
        }

        if (_currentInteractable != interactable)
        {
            interactable.OnHoverEnter();
            _currentInteractable = interactable;
        }


    }

    private void ClearInteractable()
    {
        if (_currentInteractable != null)
        {
            _currentInteractable.OnHoverExit();
            _currentInteractable = null;
        }
    }
}
