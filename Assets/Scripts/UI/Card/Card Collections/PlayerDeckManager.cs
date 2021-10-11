using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

class PlayerDeckManager : CardCollectionBase
{
    [Header("References")]
    public Transform CardsInDeckParent; // this is for organization in the hierarchy
    [SerializeField] TMP_Text _deckCountText, _deckViewCountText;
    [SerializeField] PlayerHandManager _playerHand;
    [SerializeField] PlayerDiscardManager _playerDiscard;

    [Header("Debug")]
    public List<CardData> TestDeckDatas;

    private void Start() => BuildTestDeck();

    private void BuildTestDeck()
    {
        CardCreator cardCreator = new CardCreator();
        int remainder = 10 % TestDeckDatas.Count;
        int numOfEachCard = 10 / TestDeckDatas.Count;
        int numCreated = 0;
        int currentCardIndex = 0;

        // create a ten card deck out of the cards in TestDeckDatas
        for (int i = 0; i < 10; i++)
        {
            GameObject newCard;

            // make the remainders first
            if (i < remainder)
                newCard = cardCreator.CreateCardObject(TestDeckDatas[Rng.Next(TestDeckDatas.Count)], CardsInDeckParent); // remainders will just be randomized from all available cards
            else
            {
                if (numCreated != numOfEachCard)
                    numCreated++;
                else
                {
                    numCreated = 0;
                    currentCardIndex++;
                }

                newCard = cardCreator.CreateCardObject(TestDeckDatas[currentCardIndex], CardsInDeckParent);
            }

            // disable to hide card
            newCard.SetActive(false);

            // add data to collection
            AddCardToCollection(newCard.GetComponent<CardController>());
        }

        Shuffle();
    }

    public void Draw(int numberOfCardsToDraw)
    {
        if (numberOfCardsToDraw > Cards.Count) // the player wants to draw more than we have in the deck
        {
            if (Cards.Count > 0) // we still have cards for them to draw before we shuffle in the discard
            {
                numberOfCardsToDraw -= Cards.Count;
                Draw(Cards.Count); // draw the rest in the deck                
            }

            // now shuffle in the discard pile
            _playerDiscard.ReturnCardsToDeck();
            Shuffle();
            UpdateCardCount();
        }

        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            if (_playerHand.AddCardToCollection(Cards[0])) // if we successfully add the card to the player's hand
            {
                RemoveCardFromCollection(Cards[0]);
                UpdateCardCount();
            }
            else
                break; // we've run out of room in the hand
        }
    }

    void UpdateCardCount()
    {
        _deckCountText.text = Cards.Count.ToString();
        _deckViewCountText.text = _deckCountText.text;
    }

    public override bool AddCardToCollection(CardController cardToAdd)
    {
        // set parent
        cardToAdd.transform.SetParent(CardsInDeckParent);

        // add card data
        Cards.Add(cardToAdd);

        // set deck counter text
        UpdateCardCount();

        return true;
    }

    public override bool RemoveCardFromCollection(CardController cardToRemove)
    {
        Cards.Remove(cardToRemove);
        UpdateCardCount();
        return true;
    }
}
