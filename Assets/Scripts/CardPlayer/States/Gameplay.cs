using UnityEngine;
using UnityEngine.InputSystem;

public class Gameplay : CardPlayerState
{
    public Gameplay(CardPlayer cardPlayer) : base(cardPlayer)
    {
    }

    public override void Start()
    {
        // TODO: remove selected effect on card in previously selected slot
        CardPlayer.LastSlotPressed = null;

        // hide targeting indicators
        CardPlayer.TargetingManager.HideIndicators();
    }

    public override void AbilityButtonPressed(InputAction.CallbackContext obj)
    {
        CardUISlot slotPressed = CardPlayer.DetermineSlotFromKeybindName(obj.action.name);
        if (slotPressed.CardCurrentlyInSlot != null)
        {
            CardPlayer.LastSlotPressed = slotPressed;
            CardPlayer.SetState(new CardSelected(CardPlayer));
        }
    }

    public override void MouseClicked(InputAction.CallbackContext obj)
    {
        // nothing to do in normal gameplay with a mouse click
    }
}

