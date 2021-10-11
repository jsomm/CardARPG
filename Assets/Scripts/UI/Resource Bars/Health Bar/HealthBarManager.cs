using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _healthBarPrefab;

    [Header("Configuration Options")]
    [SerializeField] int _numOfHealthBars = 3;

    private List<HealthBar> _barsWithHealth => _healthBars.FindAll(x => !x.IsExpended);

    readonly List<HealthBar> _healthBars = new List<HealthBar>();

    private void Start() => InitializeHealth();

    void InitializeHealth()
    {
        for (int i = 0; i < _numOfHealthBars; i++)
            AddHealthBar();
    }

    public void ChangeMaxHealth(int delta)
    {
        _numOfHealthBars += delta;
        while (_healthBars.Count != _numOfHealthBars)
        {
            if (_healthBars.Count > _numOfHealthBars)
                RemoveHealthBar();
            else
                AddHealthBar();
        }
    }

    private void AddHealthBar()
    {
        GameObject newHealthBar = Instantiate(_healthBarPrefab, transform);
        _healthBars.Add(newHealthBar.GetComponent<HealthBar>());
    }

    private void RemoveHealthBar()
    {
        _healthBars.Remove(_healthBars[_healthBars.Count - 1]);
        Destroy(_healthBars[_healthBars.Count - 1].gameObject);
    }

    public void TakeDamage(float dmgAmount)
    {
        foreach (HealthBar bar in _healthBars.Where(x => x.IsRegen))
            bar.StopRegen();

        float dmgRemainder = _barsWithHealth[_barsWithHealth.Count - 1].TakeDamage(dmgAmount);

        if (_barsWithHealth.Count == 0) // did the player die?
            Debug.Log("YOU DIED! :O");
        else if (dmgRemainder > 0)      // is there more damage to take?
            TakeDamage(dmgRemainder);
        else                            // we survived.. start regen
            _barsWithHealth[_barsWithHealth.Count - 1].StartRegen();
    }
}
