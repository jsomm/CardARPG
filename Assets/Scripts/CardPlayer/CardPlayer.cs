using System;

using Mirror;

using TMPro;

using UnityEngine;

public class CardPlayer : CardPlayerStateMachine
{
    [Header("References")]
    // public ResourceBarManager ResourceBarManager;
    // public CardPlayArea CardPlayArea;
    public PlayerAbilityTargetingManager TargetingManager;
    public Transform ProjectileOrigin;

    ManaBarManager _manaBar;
    PlayerDeckManager _playerDeck;
    PlayerHandManager _playerHand;
    CardUISlot _lastSlotPressed = null;

    internal ManaBarManager ManaBar { get => _manaBar; }
    internal PlayerDeckManager PlayerDeck { get => _playerDeck; }
    internal PlayerHandManager PlayerHand { get => _playerHand; }
    internal CardUISlot LastSlotPressed { get => _lastSlotPressed; set => _lastSlotPressed = value; }

    Controls _controls;
    Controls Controls => _controls ??= new Controls();

    public override void OnStartAuthority()
    {
        _playerDeck = GameObject.Find("Player Deck").GetComponent<PlayerDeckManager>();
        _playerHand = GameObject.Find("Player Hand").GetComponent<PlayerHandManager>();
        _manaBar = GameObject.Find("Mana Bar").GetComponent<ManaBarManager>();
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
    private void PlayRangedProjectileCard(CardNetworkData card) => SpawnPrefabOnServer(card.ProjectileID, ProjectileOrigin.position, ProjectileOrigin.rotation);

    [Server]
    private void PlayRangedAOECard(CardNetworkData card)
    {
        Vector3 targetPosition = TargetingManager.AoeIndicatorTransform.position;
        targetPosition.y = 0;

        SpawnPrefabOnServer(card.ProjectileID, targetPosition, TargetingManager.AoeIndicatorTransform.rotation);
    }

    [Server]
    private void PlayBuffCard(CardNetworkData card) => throw new NotImplementedException();

    [Server]
    public void SpawnPrefabOnServer(int prefabID, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = NetworkManager.singleton.spawnPrefabs[prefabID];
        GameObject projectile = Instantiate(prefab, position, rotation);
        NetworkServer.Spawn(projectile);
    }
}
