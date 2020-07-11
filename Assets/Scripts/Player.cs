using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance => instance;

    [SerializeField] private float maxEnergy = 0;
    public float currentEnergy;

    [SerializeField] private float moveSpeedCurled = 0;
    [SerializeField] private float moveSpeedUncurled = 0;
    public float currentMoveSpeed;

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
        currentEnergy = maxEnergy;
    }
}
