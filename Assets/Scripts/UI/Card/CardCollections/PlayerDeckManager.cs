using System;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

class PlayerDeckManager : CardCollectionBase
{
    [Header("References")]
    public List<CardController> CardsInDeck;
    [SerializeField] TMP_Text _deckCountText;
    [SerializeField] Transform _cardsInDeckParentObject; // this is for organization in the hierarchy
    [SerializeField] PlayerHandManager _playerHand;
    [SerializeField] PlayerDiscardManager _playerDiscard;

    [Header("Debug")]
    public List<GameObject> PrefabsInTestDeck;

    System.Random _rng;

    private void Start()
    {
        _rng = new System.Random();
        BuildTestDeck();
    }

    private void BuildTestDeck()
    {
        CardCreator cardCreator = new CardCreator();
        int remainder = 10 % PrefabsInTestDeck.Count;
        int numOfEachCard = 10 / PrefabsInTestDeck.Count;
        int numCreated = 0;
        int currentCardIndex = 0;

        // create a ten card deck out of the cards in PrefabsInTestDeck
        for (int i = 0; i < 10; i++)
        {
            GameObject newCard;

            // make the remainders first
            if (i < remainder)
                newCard = cardCreator.CreateCardObject(PrefabsInTestDeck[_rng.Next(PrefabsInTestDeck.Count)], _cardsInDeckParentObject); // remainders will just be randomized from all available cards
            else
            {
                if (numCreated != numOfEachCard)
                    numCreated++;
                else
                {
                    numCreated = 0;
                    currentCardIndex++;
                }
                newCard = cardCreator.CreateCardObject(PrefabsInTestDeck[currentCardIndex], _cardsInDeckParentObject);
            }

            // disable to hide card
            newCard.SetActive(false);

            // add data to collection
            AddCardToCollection(newCard.GetComponent<CardController>());
        }

        Shuffle();
    }

    public void Shuffle()
    {
        _rng = new System.Random();
        int n = CardsInDeck.Count;
        while (n > 1)
        {
            n--;
            int k = _rng.Next(n + 1);
            CardController value = CardsInDeck[k];
            CardsInDeck[k] = CardsInDeck[n];
            CardsInDeck[n] = value;
        }
    }

    public void Draw(int numberOfCardsToDraw)
    {
        if (numberOfCardsToDraw > CardsInDeck.Count) // the player wants to draw more than we have in the deck
        {
            if (CardsInDeck.Count > 0) // we still have cards for them to draw before we shuffle in the discard
            {
                numberOfCardsToDraw -= CardsInDeck.Count;
                Draw(CardsInDeck.Count); // draw the rest in the deck                
            }

            // now shuffle in the discard pile
            _playerDiscard.ReturnCardsToDeck();
            Shuffle();
            UpdateCardCount();
        }

        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            if (_playerHand.AddCardToCollection(CardsInDeck[0])) // if we successfully add the card to the player's hand
            {
                RemoveCardFromCollection(CardsInDeck[0]);
                UpdateCardCount();
            }
            else
                break; // we've run out of room in the hand
        }
    }

    void UpdateCardCount() => _deckCountText.text = CardsInDeck.Count.ToString();

    public override bool AddCardToCollection(CardController cardToAdd)
    {
        // set parent
        cardToAdd.transform.SetParent(_cardsInDeckParentObject);

        // add card data
        CardsInDeck.Add(cardToAdd);

        // set deck counter text
        UpdateCardCount();

        return true;
    }

    public override bool RemoveCardFromCollection(CardController cardToRemove)
    {
        CardsInDeck.Remove(cardToRemove);
        UpdateCardCount();
        return true;
    }
}
