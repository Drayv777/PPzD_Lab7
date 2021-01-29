using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class ForestTriggerController : MonoBehaviour
{
    [SerializeField, EventRef] string onSwitch;

    int zone = -1;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && zone != 0) {
            SwitchZone(0);
            zone = 0;
        }
    }

    void SwitchZone(float parameter) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(onSwitch);
        eventInstance.setParameterByName("Area", parameter);
        eventInstance.start();
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && zone != 1) {
            SwitchZone(10);
            zone = 1;
        }
    }
}
