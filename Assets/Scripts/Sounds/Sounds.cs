using UnityEngine;

public class Sounds : MonoBehaviour
{
    private FMOD.Studio.EventInstance CurlSound;
    private FMOD.Studio.EventInstance UncurlSound;
    private FMOD.Studio.EventInstance CollisionSound;
    private FMOD.Studio.EventInstance RollSound;
    private FMOD.Studio.EventInstance WalkSound;
    private FMOD.Studio.EventInstance DrainingEnergySound;
    private FMOD.Studio.EventInstance EnergyBurstSound;
    private FMOD.Studio.EventInstance ChargingArrowSound;
    private FMOD.Studio.EventInstance SubmitSound;

    private void Start()
    {
        CurlSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_ballin");
        UncurlSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_ballout");
        CollisionSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_collide_other");
        RollSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_roll");
        WalkSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_steps");
        DrainingEnergySound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_straw");
        EnergyBurstSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gurtel/Gurtel_straw_fast");
        ChargingArrowSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Control/direction_charge");
        SubmitSound = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Control/direction_letgo");

        SoundEventManager.OnCurl += PlayCurlSound;
        SoundEventManager.OnUncurl += PlayUncurlSound;
        SoundEventManager.OnCollision += PlayCollisionSound;
        SoundEventManager.OnRoll += PlayRollSound;
        SoundEventManager.OnWalk += PlayWalkSound;
        SoundEventManager.OnActivateDrainingEnergy += PlayDrainingEnergySound;
        SoundEventManager.OnDeactivateDrainingEnergy += StopDrainingEnergySound;
        SoundEventManager.OnChangeEnergyLevel += ChangeEnergyLevel;
        SoundEventManager.OnPressingCurlButton += PlayEnergyDrainBurst;

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
    private void PlayDrainingEnergySound()
    {
        DrainingEnergySound.start();
        ChargingArrowSound.start();
    }

    private void StopDrainingEnergySound()
    {
        DrainingEnergySound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        ChargingArrowSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SubmitSound.start();
    }

    private void ChangeEnergyLevel(float value)
    {
        DrainingEnergySound.setParameterByName("energybar", value);
    }

    private void PlayEnergyDrainBurst()
    {
        EnergyBurstSound.start();
        SubmitSound.start();
    }
}
