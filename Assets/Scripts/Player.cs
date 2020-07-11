using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance => instance;

    [SerializeField] private float maxEnergy = 0;
    [SerializeField] private FloatVariable currentEnergy = null;
    [SerializeField] private float moveSpeedCurled = 0;
    [SerializeField] private float moveSpeedUncurled = 0;

    private float currentMoveSpeed = 0;
    public float CurrentMoveSpeed => currentMoveSpeed;

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
        currentMoveSpeed = moveSpeedUncurled;
        rb = GetComponent<Rigidbody>();
    }

    public void ToggleCurlAbility()
    {
        isCurled = !isCurled;
        rb.isKinematic = !rb.isKinematic;

        if (isCurled)
        {
            currentMoveSpeed = moveSpeedCurled;
        }
        else
        {
            currentMoveSpeed = moveSpeedUncurled;
        }
    }
}
