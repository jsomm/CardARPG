using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class PlayerDiscardManager : CardCollectionBase
{
    public List<CardController> CardsInDiscard;

    [Header("References")]
    [SerializeField] PlayerDeckManager _playerDeck;
    [SerializeField] Transform _cardsInDiscardParentObject; // this is for organization in the hierarchy
    [SerializeField] TMP_Text _discardCountText;

    private void Start() => UpdateCardCount();

    public override bool AddCardToCollection(CardController cardToAdd)
    {
        // set parent for organization
        cardToAdd.gameObject.transform.SetParent(_cardsInDiscardParentObject);

        // add card data
        CardsInDiscard.Add(cardToAdd);

        // set inactive to hide card
        cardToAdd.gameObject.SetActive(false);

        UpdateCardCount();

        return true;
    }

    public override bool RemoveCardFromCollection(CardController cardToRemove)
    {
        if (CardsInDiscard.Contains(cardToRemove))
        {
            CardsInDiscard.Remove(cardToRemove);
            UpdateCardCount();
            return true;
        }
        else
            return false; // we couldn't find the card
    }

    void UpdateCardCount() => _discardCountText.text = CardsInDiscard.Count.ToString();

    public void ReturnCardsToDeck()
    {
        List<CardController> cardReturnList = CardsInDiscard.GetRange(0, CardsInDiscard.Count); // clone the list so we can remove all the old elements and still return them to the deck
        foreach (CardController card in cardReturnList)
        {
            _playerDeck.AddCardToCollection(card);
            RemoveCardFromCollection(card);
        }
    }
}
