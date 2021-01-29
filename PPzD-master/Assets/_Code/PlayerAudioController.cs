using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudioController : PlayerSubsystem {

    
    #pragma warning disable 0649
    [SerializeField, EventRef] string onStep;
    [SerializeField, EventRef] string onJump;
    [SerializeField, EventRef] string onLanding;
    [SerializeField, EventRef] string onDeath;
    [SerializeField, EventRef] string onAttack;
    [SerializeField, EventRef] string onDamage;
    [SerializeField, EventRef] string onBlock;
    [SerializeField, EventRef] string onHeartBeatStart;
    [SerializeField, EventRef] string parameters;

    bool heartBeatOn;
    
    public override void HandleEvent(PlayerEventType eventType) {
        switch (eventType) {
            case PlayerEventType.Jump:
                RuntimeManager.PlayOneShot(onJump);
                break;
            case PlayerEventType.Landing:
                RuntimeManager.PlayOneShot(onLanding);
                break;
            case PlayerEventType.Death:
                RuntimeManager.PlayOneShot(onDeath);
                break;
            case PlayerEventType.Attack:
                RuntimeManager.PlayOneShot(onAttack);
                break;
            case PlayerEventType.Footstep:
                RuntimeManager.PlayOneShot(onStep);
                break;
            case PlayerEventType.Damage:
                RuntimeManager.PlayOneShot(onDamage);
                break;
            case PlayerEventType.Block:
                RuntimeManager.PlayOneShot(onBlock);
                break;
        }
    }

    public void UpdateHeartBeat(float f) {
        if (!heartBeatOn) {
            RuntimeManager.PlayOneShot(onHeartBeatStart);
            heartBeatOn = true;
        }
        EventInstance eventInstance = RuntimeManager.CreateInstance(parameters);
        eventInstance.setParameterByName("HeartBeatRate", f);
        eventInstance.start();
        Debug.Log("hearbeat at " + f*100 + "%");
    }
}
