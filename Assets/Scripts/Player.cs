using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player Instance;

    void Start()
    {
        Instance = this;
    }
}
