using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance ambienceSound;

    private void Start()
    {
        ambienceSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambi/srong wind");
        ambienceSound.start();
    }
}
