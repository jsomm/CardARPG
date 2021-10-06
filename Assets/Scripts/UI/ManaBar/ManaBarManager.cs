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
    List<Image> _manaPointImages;

    Vector2 _padding;

    private void Awake() => _backgroundRect = GetComponent<RectTransform>();

    private void Start()
    {
        _manaPointImages = new List<Image>();
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

        if (_manaPointImages.Count <= 0)
        {
            _backgroundRect.sizeDelta += new Vector2(_paddingBetweenPoints, 0);
            newManaPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2((5 + _paddingBetweenPoints), 0);
        }
        else
        {
            Vector2 previousPointPosition = _manaPointImages[_manaPointImages.Count - 1].gameObject.GetComponent<RectTransform>().anchoredPosition;
            newManaPoint.GetComponent<RectTransform>().anchoredPosition = previousPointPosition + _padding;
        }

        _backgroundRect.anchoredPosition = new Vector2((_backgroundRect.sizeDelta.x / 2) + _paddingFromLeftSideOfScreen, 0);
        _manaPointImages.Add(newManaPoint.GetComponent<Image>());
    }

    public void AddManaPoint()
    {
        MaxManaPoints++;
        AddPointToBar();
    }
}
