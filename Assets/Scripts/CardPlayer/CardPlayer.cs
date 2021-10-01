using System;

using Mirror;

using UnityEngine;

public class CardPlayer : CardPlayerStateMachine
{
    [Header("References")]
    // public ResourceBarManager ResourceBarManager;
    // public CardPlayArea CardPlayArea;
    public PlayerAbilityTargetingManager TargetingManager;
    public Transform ProjectileOrigin;

    private PlayerHandManager _playerHand;
    private CardUISlot _lastSlotPressed = null;

    public CardUISlot LastSlotPressed { get => _lastSlotPressed; set => _lastSlotPressed = value; }
    public PlayerHandManager PlayerHand { get => _playerHand; set => _playerHand = value; }

    Controls _controls;
    public Controls Controls => _controls ??= new Controls();

    public override void OnStartAuthority()
    {
        _playerHand = GameObject.Find("Player Hand").GetComponent<PlayerHandManager>();
        // ResourceBarManager = GameObject.Find("Resource Bars").GetComponent<ResourceBarManager>();
        SetState(new Gameplay(this));

        Controls.PlayerControls.AbilityOne.performed += HandleAbilityButtonPressed;
        Controls.PlayerControls.AbilityTwo.performed += HandleAbilityButtonPressed;
        Controls.PlayerControls.AbilityThree.performed += HandleAbilityButtonPressed;
        Controls.PlayerControls.AbilityFour.performed += HandleAbilityButtonPressed;
        Controls.PlayerControls.LeftClick.performed += HandleMouseClicked;
    }

    [ClientCallback]
    private void OnEnable() => Controls.PlayerControls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.PlayerControls.Disable();

    [Client]
    private void HandleAbilityButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => State.AbilityButtonPressed(obj);

    [Client]
    private void HandleMouseClicked(UnityEngine.InputSystem.InputAction.CallbackContext obj) => State.MouseClicked(obj);

    [Client]
    public CardUISlot DetermineSlotFromKeybindName(string actionName)
    {
        switch (actionName)
        {
            case "AbilityOne":
                return PlayerHand.CardSlots[0];
            case "AbilityTwo":
                return PlayerHand.CardSlots[1];
            case "AbilityThree":
                return PlayerHand.CardSlots[2];
            case "AbilityFour":
                return PlayerHand.CardSlots[3];
            default:
                break;
        }

        return null;
    }

    [Command]
    public void CmdPlayCard(CardNetworkData card)
    {
        switch (card.Type)
        {
            case CardData.CardType.RangedProjectile:
                PlayRangedProjectileCard(card);
                break;
            case CardData.CardType.RangedAOE:
                PlayRangedAOECard(card);
                break;
            case CardData.CardType.Buff:
                PlayBuffCard(card);
                break;
        }
    }

    [Server]
    private void PlayRangedProjectileCard(CardNetworkData card)
    {
        GameObject prefab = NetworkManager.singleton.spawnPrefabs[card.ProjectileID];
        GameObject projectile = Instantiate(prefab, ProjectileOrigin.position, ProjectileOrigin.rotation);
        NetworkServer.Spawn(projectile);
    }

    [Server]
    private void PlayRangedAOECard(CardNetworkData card)
    {
        GameObject prefab = NetworkManager.singleton.spawnPrefabs[card.ProjectileID];
        Vector3 targetPosition = TargetingManager.AoeIndicatorTransform.position;
        targetPosition.y = 0;

        GameObject projectile = Instantiate(prefab, targetPosition, TargetingManager.AoeIndicatorTransform.rotation);
        NetworkServer.Spawn(projectile);
    }

    [Server]
    private void PlayBuffCard(CardNetworkData card) => throw new NotImplementedException();
}
