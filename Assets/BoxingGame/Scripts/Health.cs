using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;

    [SerializeField] private Bar _healthBar;

    [SerializeField] private RectTransform _gameOverPanel;

    public void Heal()
    {
        int heal = Random.Range(20,30);

        _health = Mathf.Min(_health + heal, _maxHealth);

        UpdateHealthBar();
        CheckForDeath();
    }

    //DealDamage(20);
    public void DealDamage(int damage)
    {
        _health = Mathf.Max(0, _health - damage);
        UpdateHealthBar();
        CheckForDeath();
    }

    //int x = CurrentHealth();
    public int CurrentHealth()
    {
        return _health;
    }

    public void UpdateHealthBar()
    {
        _healthBar.SetBar((float)_health, (float) _maxHealth);
    }

    public void CheckForDeath()
    {
        if (_health <= 0)
        {
            _gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
