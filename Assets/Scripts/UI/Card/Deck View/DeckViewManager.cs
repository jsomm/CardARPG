using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class DeckViewManager : MonoBehaviour
{
    [SerializeField] PlayerDeckManager _deckManager;
    [SerializeField] Transform _menuCardsParent;
    [SerializeField] GameObject _GFXWrapper;

    GameObject _deckViewCardPrefab;
    List<CardController> _menuCards = new List<CardController>();

    bool _isOpen = false;

    void Awake() => _deckViewCardPrefab = Resources.Load<GameObject>("Cards/_MenuCard");

    void Start() => CreateDeckViewCardClones();

    void CreateDeckViewCardClones()
    {
        foreach (CardController card in _deckManager.CardsInDeck)
        {
            GameObject deckViewCard = Instantiate(_deckViewCardPrefab, _menuCardsParent);
            CardController cardController = deckViewCard.GetComponent<CardController>();
            cardController.CardData = card.CardData;
            cardController.ParentCard = card.gameObject;
            _menuCards.Add(cardController);

            deckViewCard.SetActive(false);
        }        
    }

    public void ToggleDeckView()
    {
        if (!_isOpen)
        {
            _GFXWrapper.SetActive(true);
            ShowCurrentDeck();            
        }
        else
        {
            _GFXWrapper.SetActive(false);
            HideCurrentDeck();
        }
        _isOpen = !_isOpen;
    }

    void ShowCurrentDeck()
    {
        _deckManager.Shuffle();
        foreach (CardController card in _deckManager.CardsInDeck)
        {
            CardController menuCard = _menuCards.Find(x => x.ParentCard == card.gameObject);
            if (menuCard != null)
            {
                menuCard.gameObject.SetActive(true);
            }
        }
    }

    void HideCurrentDeck()
    {
        foreach(CardController card in _menuCards)
        {
            card.gameObject.SetActive(false);
        }
    }
}
