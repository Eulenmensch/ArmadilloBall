using UnityEngine;
using System.Collections.Generic;

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

    private Dictionary<Collider, ContactPoint[]> collisions = new Dictionary<Collider, ContactPoint[]>();


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

    public void ActivateCurlAbility()
    {
        isCurled = true;
        rb.isKinematic = false;
        SoundEventManager.Curl();
    }

    public void DeactivateCurlAbility()
    {
        isCurled = false;
        rb.isKinematic = true;
        SoundEventManager.Uncurl();
    }

    public void ResetEnergyAmount()
    {
        currentEnergy.value = maxEnergy;
    }

    private void OnCollisionStay(Collision collision)
    {
        collisions[collision.collider] = collision.contacts;
    }

    private void OnCollisionExit(Collision collision)
    {
        collisions.Remove(collision.collider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions.Add(collision.collider, collision.contacts);

        if (Vector3.Magnitude(collision.relativeVelocity) > 3f)
            SoundEventManager.Collision();
    }

    public bool IsFalling()
    {
        foreach(var contactPoints in collisions)
        {
            foreach(ContactPoint contactPoint in contactPoints.Value)
            {
                if (transform.position.y > contactPoint.point.y)
                    return false;
            }
        }
        return true;
    }

    public Vector3 GetNormalOfGround()
    {
        foreach (var contactPoints in collisions)
        {
            foreach (ContactPoint contactPoint in contactPoints.Value)
            {
                if (transform.position.y > contactPoint.point.y)
                    return contactPoint.normal;
            }
        }

        return Vector3.zero;
    }
}
