using UnityEngine;

public abstract class CardCollectionBase : MonoBehaviour
{
    public abstract bool AddCardToCollection(CardController cardToAdd);
    public abstract bool RemoveCardFromCollection(CardController cardToRemove);
}

