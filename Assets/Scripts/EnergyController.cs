using UnityEngine;
using System.Collections;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private MovementController input = null;

    [SerializeField] private FloatVariable energy = null;
    [SerializeField] private float energyCostPerSecond = 0;
    [SerializeField] private float energyCostCurleToggle = 0;

    public float EnergyCostCurleToggle => energyCostCurleToggle;

    private bool isEnergyDraining = false;

    public void Update()
    {
        if(isEnergyDraining)
        {
            energy.value -= energyCostPerSecond * Time.deltaTime;
            SoundEventManager.ChangeEnergyLevel((100f - energy.value) / 100f);
            if (energy.value <= 0)
            {
                energy.value = 0;
                StopEnergyDrain();
                input.SendMoveCommand();
            }
        }
    }

    public void StartEnergyDrain()
    {
        isEnergyDraining = true;
        SoundEventManager.ActivateDrainingEnergy();
    }

    public void StopEnergyDrain()
    {
        isEnergyDraining = false;
        SoundEventManager.DeactivateDrainingEnergy();
    }

}
