using UnityEngine;
using System.Collections;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private InputTest input;

    [SerializeField] private FloatVariable energy;
    [SerializeField] private float energyCostPerSecond = 0;
    [SerializeField] private float energyCostJump = 0;

    private bool isEnergyDraining = false;

    public void Update()
    {
        if(isEnergyDraining)
        {
            energy.value -= energyCostPerSecond * Time.deltaTime;
            if(energy.value <= 0)
            {
                energy.value = 0;
                isEnergyDraining = false;
                input.SendMoveCommand();
            }
        }
    }

    public void StartEnergyDrain()
    {
        isEnergyDraining = true;
    }

    public void StopEnergyDrain()
    {
        isEnergyDraining = false;
    }

}
