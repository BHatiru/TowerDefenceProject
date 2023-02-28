using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TowerOptionsPanel : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _sellButton;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        UnityAction onClickAction = () =>{
            SceneEventSystem.Instance.NotifyUpgradeButtonPressed();
        };
        _upgradeButton.onClick.AddListener(onClickAction);
    }
    /*private void Start()
    {
        _upgradeButton.onClick.AddListener(NotifyEvent);
    }

    private void NotifyEvent()
    {
        SceneEventSystem.Instance.NotifyUpgradeButtonPressed();
    }*/

    public void Show()
    {
        _animator.SetBool("show", true);
    }

    public void Hide()
    {
        _animator.SetBool("show", false);
    }
}
