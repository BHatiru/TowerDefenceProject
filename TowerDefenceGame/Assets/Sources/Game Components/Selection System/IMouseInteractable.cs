using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInteractable 
{
    void OnHoverEnter();
    void OnHoverExit();
    void OnClick();
    void Deselect();
}
