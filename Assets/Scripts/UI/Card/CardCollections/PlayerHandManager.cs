using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PlayerHandManager : CardCollectionBase
{
    [Header("References")]
    [SerializeField] PlayerDiscardManager _playerDiscard;

    public List<CardController> CardsInHand;
    public List<CardUISlot> CardSlots;


    public override bool AddCardToCollection(CardController cardToAdd)
    {
        // find the first unoccupied slot to put the new card in
        CardUISlot targetSlot = CardSlots.FirstOrDefault(x => x.CardCurrentlyInSlot == null);

        // do we have room in hand for this card?
        if (targetSlot != null)
        {
            // add data to list of cards in hand
            CardsInHand.Add(cardToAdd);

            // tell the card's dragdrop where we are and allow dragging                
            CardDragDrop dragDrop = cardToAdd.DragDrop;
            dragDrop.StartPos = cardToAdd.transform.position;
            dragDrop.CurrentSlot = targetSlot;
            dragDrop.AllowDragging = true;

            // tell the card about the slot and arrange it on the screen
            cardToAdd.CurrentSlot = targetSlot;
            cardToAdd.transform.SetParent(targetSlot.transform);
            cardToAdd.gameObject.SetActive(true); // set active so the card is visible

            // tell the target slot about the card
            targetSlot.PlaceCardInSlot(cardToAdd);

            // little flip animation as it enters the hand
            cardToAdd.FlipCard();

            return true;
        }
        else
            return false;
    }

    public override bool RemoveCardFromCollection(CardController cardToRemove)
    {
        if (CardsInHand.Contains(cardToRemove))
        {
            // remove the card from the hand slot, the hand data list, and send it to the discard pile
            cardToRemove.CurrentSlot.RemoveCardFromSlot();
            CardsInHand.Remove(cardToRemove);

            // send the card to the discard pile
            _playerDiscard.AddCardToCollection(cardToRemove);

            return true;
        }
        else
            return false; // we did not remove anything
    }
}