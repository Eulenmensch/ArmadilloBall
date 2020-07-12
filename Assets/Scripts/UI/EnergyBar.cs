using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] FloatVariable energy;

    private float maxEnergy;
    private Image image;

    private void Start()
    {
        maxEnergy = energy.value;
        image = GetComponent<Image>();
    }
    void Update()
    {
        image.fillAmount = energy.value / maxEnergy;
    }
}
