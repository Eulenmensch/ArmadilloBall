using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private FMOD.Studio.EventInstance inputPhaseMusic;
    private FMOD.Studio.EventInstance executionPhaseMusic;

    private void Start()
    {
        inputPhaseMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Musik/Phase 1");
        executionPhaseMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Musik/Phase 2");
        GameManager.Instance.OnInputPhase += PlayInputPhaseMusic;
        GameManager.Instance.OnExecutionPhase += PlayExecutionPhaseMusic;
        GameManager.Instance.OnWin += TransitionToWin;

        inputPhaseMusic.setParameterByName("egitarre an", 1);
        inputPhaseMusic.setParameterByName("agitarre an", 1);
        inputPhaseMusic.setParameterByName("horns an", 1);


        inputPhaseMusic.start();
    }

    private void PlayInputPhaseMusic()
    {
        executionPhaseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        inputPhaseMusic.start();
    }

    private void PlayExecutionPhaseMusic()
    {
        inputPhaseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        executionPhaseMusic.start();
    }

    private void TransitionToWin()
    {
        executionPhaseMusic.setParameterByName("Winning", 1);
    }


}
