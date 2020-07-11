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
    [SerializeField] private float curledDrag = 0;
    [SerializeField] private float curledAngularDrag = 0;

    private float currentMoveSpeed = 0;
    public float CurrentMoveSpeed => currentMoveSpeed;

    private bool isCurled = false;
    public bool IsCurled => isCurled;

    private Rigidbody rb;


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

        if (isCurled)
        {
            currentMoveSpeed = moveSpeedCurled;
            rb.drag = curledDrag;
            rb.angularDrag = curledAngularDrag;
        }
        else
        {
            currentMoveSpeed = moveSpeedUncurled;
            rb.drag = Mathf.Infinity;
            rb.angularDrag = Mathf.Infinity;
        }
    }
}
