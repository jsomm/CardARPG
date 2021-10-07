using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ManaBarManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _manaPointPrefab;

    [Header("Configuration Options")]
    [SerializeField] float _paddingBetweenPoints = 5;
    [SerializeField] float _paddingFromLeftSideOfScreen = 10;
    public int MaxManaPoints = 5;

    RectTransform _backgroundRect;
    List<ManaPoint> _manaPoints;

    List<ManaPoint> _currentManaPoints => _manaPoints.FindAll(x => !x.IsExpended);


    Vector2 _padding;

    private void Awake() => _backgroundRect = GetComponent<RectTransform>();

    private void Start()
    {
        _manaPoints = new List<ManaPoint>();
        _padding = new Vector2((_paddingBetweenPoints + _manaPointPrefab.GetComponent<RectTransform>().rect.width), 0);

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
        _backgroundRect.sizeDelta += _padding;
        GameObject newManaPoint = Instantiate(_manaPointPrefab, _backgroundRect);

        if (_manaPoints.Count <= 0)
        {
            _backgroundRect.sizeDelta += new Vector2(_paddingBetweenPoints, 0);
            newManaPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2((5 + _paddingBetweenPoints), 0);
        }
        else
        {
            Vector2 previousPointPosition = _manaPoints[_manaPoints.Count - 1].gameObject.GetComponent<RectTransform>().anchoredPosition;
            newManaPoint.GetComponent<RectTransform>().anchoredPosition = previousPointPosition + _padding;
        }

        _backgroundRect.anchoredPosition = new Vector2((_backgroundRect.sizeDelta.x / 2) + _paddingFromLeftSideOfScreen, 0);
        _manaPoints.Add(newManaPoint.GetComponent<ManaPoint>());
    }

    public void AddManaPoint()
    {
        MaxManaPoints++;
        AddPointToBar();
    }

    public bool ConsumeMana(int amount)
    {
        if (amount > _currentManaPoints.Count)
            return false; // not enough mana
        else
        {
            for (int i = 0; i < amount; i++)
            {
                _currentManaPoints[(_currentManaPoints.Count - 1)].Consume();
            }
            return true;
        }
    }

    public void ConsumeManaTest(int amount)
    {
        if (amount > _currentManaPoints.Count)
            return; // not enough mana
        else
        {
            for (int i = 0; i < amount; i++)
            {
                _currentManaPoints[(_currentManaPoints.Count - 1)].Consume();
            }
        }
    }
}
