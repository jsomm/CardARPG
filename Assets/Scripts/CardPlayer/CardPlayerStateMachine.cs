using UnityEngine;
using Mirror;

public abstract class CardPlayerStateMachine : NetworkBehaviour
{
    protected CardPlayerState State;

    public void SetState(CardPlayerState state)
    {
        State = state;
        State.Start();
    }
}