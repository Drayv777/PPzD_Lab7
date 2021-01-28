using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudioController : PlayerSubsystem {

    public override void HandleEvent(PlayerEventType eventType) {
        switch (eventType) {
            case PlayerEventType.Jump:
                //TODO play jump sound
                break;
            case PlayerEventType.Landing:
                //TODO play landing sound
                break;
            case PlayerEventType.Death:
                break;
            case PlayerEventType.Attack:
                break;
            case PlayerEventType.Footstep:
                //TODO play random footstep sound
                break;
        }
    }
}
