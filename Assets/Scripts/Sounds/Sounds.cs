using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance CurlSound;
    private FMOD.Studio.EventInstance UncurlSound;
    private FMOD.Studio.EventInstance CollisionSound;
    private FMOD.Studio.EventInstance RollSound;
    private FMOD.Studio.EventInstance WalkSound;
    private FMOD.Studio.EventInstance DrainingEnergySound;

    private void Start()
    {
        CurlSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_ballin");
        UncurlSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_ballout");
        CollisionSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_collide_other");
        RollSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_roll");
        WalkSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_steps");
        DrainingEnergySound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_straw");

        SoundEventManager.OnCurl += PlayCurlSound;
        SoundEventManager.OnUncurl += PlayUncurlSound;
        SoundEventManager.OnCollision += PlayCollisionSound;
        SoundEventManager.OnRoll += PlayRollSound;
        SoundEventManager.OnWalk += PlayWalkSound;
        SoundEventManager.OnDrainingEnergy += PlayDrainingEnergySound;
    }

    private void PlayCurlSound()
    {
        CurlSound.start();
    }

    private void PlayUncurlSound()
    {
        UncurlSound.start();
    }
    private void PlayCollisionSound()
    {
        CollisionSound.start();
    }
    private void PlayRollSound(float speed)
    {
        RollSound.start();
    }
    private void PlayWalkSound()
    {
        WalkSound.start();
    }
    private void PlayDrainingEnergySound(float amount)
    {
        DrainingEnergySound.start();
    }
}
