using System.Collections.Generic;

using UnityEngine;

public abstract class CardCollectionBase : MonoBehaviour
{
    private List<CardController> _cards;

    public List<CardController> Cards { get => _cards ??= new List<CardController>(); set => _cards = value; }

    public abstract bool AddCardToCollection(CardController cardToAdd);
    public abstract bool RemoveCardFromCollection(CardController cardToRemove);

    protected System.Random _rng = new System.Random();

    public void Shuffle()
    {
        _rng = new System.Random();
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = _rng.Next(n + 1);
            CardController value = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = value;
        }
    }
}

