using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CurrentWeaponHUD : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Image _icon;

    private void OnEnable()
    {
        _player.WeaponChanged += SetCurrentWeaponIcon;
        _icon = GetComponent<Image>();
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= SetCurrentWeaponIcon;
    }

    public void SetCurrentWeaponIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }
}
