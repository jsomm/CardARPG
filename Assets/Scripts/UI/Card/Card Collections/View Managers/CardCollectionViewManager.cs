using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;

public class CardCollectionViewManager : MonoBehaviour
{
    [SerializeField] protected CardCollectionBase _viewTarget;
    [SerializeField] protected Transform _scrollViewContentParent;
    [SerializeField] protected GameObject _GFXWrapper;
    [SerializeField] protected bool _shuffleBeforeViewing = false;
    [SerializeField] protected TMP_Text _titleTextTMP;
    [SerializeField] protected string _titleText = "Cards in Deck";

    protected CardCollectionBase _deck;
    protected GameObject _deckViewCardPrefab;
    protected List<CardController> _menuCards = new List<CardController>();

    protected bool _isOpen = false;

    void Awake()
    {
        _deckViewCardPrefab = Resources.Load<GameObject>("Cards/_MenuCard");
        _deck = GameObject.Find("Player Deck").GetComponent<CardCollectionBase>();
    }

    private void Start()
    {
        _titleTextTMP.text = _titleText;
        CreateCardClonesFromDeck();
    }

    void CreateCardClonesFromDeck()
    {
        foreach (CardController card in _deck.Cards)
        {
            GameObject deckViewCard = Instantiate(_deckViewCardPrefab, _scrollViewContentParent);
            CardController cardController = deckViewCard.GetComponent<CardController>();
            cardController.CardData = card.CardData;
            cardController.ParentCard = card.gameObject;
            _menuCards.Add(cardController);

            deckViewCard.SetActive(false);
        }
    }

    public void ToggleView()
    {
        if (!_isOpen)
        {
            _GFXWrapper.SetActive(true);
            ShowView();
        }
        else
        {
            _GFXWrapper.SetActive(false);
            HideView();
        }
        _isOpen = !_isOpen;
    }

    void ShowView()
    {
        if (_shuffleBeforeViewing)
            _viewTarget.Shuffle();

        for (int i = 0; i < _viewTarget.Cards.Count; i++)
        {
            CardController menuCard = _menuCards.Find(x => x.ParentCard == _viewTarget.Cards[i].gameObject);
            if (menuCard != null)
            {
                menuCard.gameObject.SetActive(true);
                if (!_shuffleBeforeViewing)
                    menuCard.transform.SetSiblingIndex(i);
            }
        }

        foreach (CardController card in _viewTarget.Cards)
        {
            CardController menuCard = _menuCards.Find(x => x.ParentCard == card.gameObject);
            if (menuCard != null)
            {
                menuCard.gameObject.SetActive(true);
            }
        }
    }

    void HideView()
    {
        foreach (CardController card in _menuCards)
        {
            card.gameObject.SetActive(false);
        }
    }
}
