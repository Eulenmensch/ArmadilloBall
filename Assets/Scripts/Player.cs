using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance => instance;

    [SerializeField] private float maxEnergy = 0;
    [SerializeField] private FloatVariable currentEnergy = null;
    [SerializeField] private float moveForce = 0;

    private float currentMoveForce = 0;
    public float CurrentMoveForce => currentMoveForce;

    private bool isCurled = false;
    public bool IsCurled => isCurled;

    public Rigidbody rb;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentEnergy.value = maxEnergy;
        currentMoveForce = moveForce;
        rb = GetComponent<Rigidbody>();
    }

    public void ToggleCurlAbility()
    {
        isCurled = !isCurled;
    }

    public void ResetEnergyAmount()
    {
        currentEnergy.value = maxEnergy;
    }
}
