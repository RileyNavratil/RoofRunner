using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource[] soundFX;

    void Update()
    {
        if(Input.GetButtonDown("q")){
            soundFX[0].Play();
        }
                if(Input.GetButtonDown("p")){
            soundFX[1].Play();
        }
    }
}
