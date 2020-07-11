using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WinArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.gameObject)
            GameManager.Instance.WinGame();
    }
}
