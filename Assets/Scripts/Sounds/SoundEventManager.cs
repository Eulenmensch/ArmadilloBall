﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEventManager : MonoBehaviour
{
    public static event Action OnCurl;
    public static void Curl()
    {
        OnCurl?.Invoke();
    }

    public static event Action OnUncurl;
    public static void Uncurl()
    {
        OnUncurl?.Invoke();
    }

    public static event Action OnCollision;
    public static void Collision()
    {
        OnCollision?.Invoke();
    }

    public static event Action OnWalk;
    public static void Walk()
    {
        OnWalk?.Invoke();
    }

    public static event Action<float> OnRoll;
    public static void Roll(float speed)
    {
        OnRoll?.Invoke(speed);
    }

    public static event Action OnActivateDrainingEnergy;
    public static void ActivateDrainingEnergy()
    {
        OnActivateDrainingEnergy?.Invoke();
    }

    public static event Action OnDeactivateDrainingEnergy;
    public static void DeactivateDrainingEnergy()
    {
        OnDeactivateDrainingEnergy?.Invoke();
    }

    public static event Action<float> OnChangeEnergyLevel;
    public static void ChangeEnergyLevel(float value)
    {
        OnChangeEnergyLevel?.Invoke(value);
    }

    public static event Action OnPressingCurlButton;
    public static void PressingCurlButton()
    {
        OnPressingCurlButton?.Invoke();
    }
}
