using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTheme : MonoBehaviour
{
    private FMOD.Studio.EventInstance inputPhaseMusic;

    private void Awake()
    {
        inputPhaseMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Musik/Phase 1");
        inputPhaseMusic.setParameterByName("egitarre an", 1);
        inputPhaseMusic.setParameterByName("agitarre an", 1);
        inputPhaseMusic.setParameterByName("horns an", 1);
        inputPhaseMusic.start();     
    }
}
