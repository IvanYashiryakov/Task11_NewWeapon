using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<Sprite> WeaponChanged;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            _currentWeapon.Shoot(_shootPoint);
            //Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(mouseWorldPosition);
        }
    }

    private bool CanShoot()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Time.timeScale != 0
            && mouseWorldPosition.x - transform.position.x < 0
            && mouseWorldPosition.y - transform.position.y - _spriteRenderer.sprite.rect.size.y < 0)
            return true;

        return false;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber >= _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber <= 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        WeaponChanged?.Invoke(weapon.Icon);
    }
}
