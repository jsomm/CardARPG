using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ManaBarManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _manaPointPrefab;

    [Header("Configuration Options")]
    public int MaxManaPoints = 5;

    List<ManaPoint> _manaPoints;
    public List<ManaPoint> CurrentManaPoints => _manaPoints.FindAll(x => !x.IsExpended);

    private void Start()
    {
        _manaPoints = new List<ManaPoint>();
        CreateManaBar();
    }

    void CreateManaBar()
    {
        for (int i = 0; i < MaxManaPoints; i++)
        {
            AddPointToBar();
        }
    }

    public void AddPointToBar()
    {       
        GameObject newManaPoint = Instantiate(_manaPointPrefab, transform);
        _manaPoints.Add(newManaPoint.GetComponent<ManaPoint>());
    }

    public void AddManaPoint()
    {
        MaxManaPoints++;
        AddPointToBar();
    }

    public bool ConsumeMana(int amount)
    {
        if (amount > CurrentManaPoints.Count)
            return false; // not enough mana
        else
        {
            for (int i = 0; i < amount; i++)
            {
                CurrentManaPoints[(CurrentManaPoints.Count - 1)].Consume();
            }

            return true;
        }
    }
}
