using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        joo = FMODUnity.RuntimeManager.CreateInstance("event:/Musik/Phase 1");
        joo.setParameterByName("egitarre an", 1);
        joo.setParameterByName("horns an", 0);
        joo.start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FMOD.Studio.EventInstance joo;
}
