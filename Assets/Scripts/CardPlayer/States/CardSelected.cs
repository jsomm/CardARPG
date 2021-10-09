using System;

using UnityEngine;
using UnityEngine.InputSystem;
public class CardSelected : CardPlayerState
{
    CardData _selectedCardData;

    public CardSelected(CardPlayer cardPlayer) : base(cardPlayer)
    {
    }

    public override void Start()
    {
        // get the data for the selected card so we can use it later when we actually play it
        _selectedCardData = CardPlayer.LastSlotPressed.CardCurrentlyInSlot.CardData;

        // TODO: activate some kind of effect on the last slot pressed to indicate what card is selected
        CardPlayer.LastSlotPressed.CardCurrentlyInSlot.ToggleCardHighlight();

        // display targeting indicators for the selected card
        CardPlayer.TargetingManager.ShowIndicatorForCard(_selectedCardData);
    }

    public override void AbilityButtonPressed(InputAction.CallbackContext obj)
    {
        // check if the button pressed matches the slot we had previously selected            
        if (CardPlayer.LastSlotPressed == CardPlayer.DetermineSlotFromKeybindName(obj.action.name))
        {
            // play the card
            if (CanPlayCardInSlot(CardPlayer.LastSlotPressed))
                PlayCardInSlot();
        }
        // either we played the card or the user pressed a different button than initially pressed, so lets go back to normal gameplay state
        CardPlayer.SetState(new Gameplay(CardPlayer));
    }

    public override void MouseClicked(InputAction.CallbackContext obj)
    {
        if (CanPlayCardInSlot(CardPlayer.LastSlotPressed))
            PlayCardInSlot();

        // back to normal gameplay
        CardPlayer.SetState(new Gameplay(CardPlayer));
    }

    private bool CanPlayCardInSlot(CardUISlot slot)
    {
        // if we have enough mana for the card return true
        if (CardPlayer.ManaBar.CurrentManaPoints.Count >= slot.CardCurrentlyInSlot.CardData.Cost)
            return true;
        else
        {
            Debug.Log("Not enough mana!");
            return false;
        }
    }

    private void PlayCardInSlot()
    {
        // get info needed to play the card
        CardNetworkData data = CardPlayer.LastSlotPressed.CardCurrentlyInSlot.CardData.GetNetworkData(new CardNetworkData());

        // use mana
        CardPlayer.ManaBar.ConsumeMana(data.Cost);

        // play the card
        CardPlayer.CmdPlayCard(data);

        // remove the selected effect from the card
        CardPlayer.LastSlotPressed.CardCurrentlyInSlot.ToggleCardHighlight();

        // remove the card from the hand
        CardPlayer.PlayerHand.RemoveCardFromCollection(CardPlayer.LastSlotPressed.CardCurrentlyInSlot);
    }
}

