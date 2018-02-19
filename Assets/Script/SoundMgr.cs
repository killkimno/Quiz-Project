using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public enum SoundType
    {
        None, Button,
    };

    public static SoundMgr instance;

    public AudioSource clickSound;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySound(SoundType soundType)
    {
        if(soundType == SoundType.Button)
        {
            instance.clickSound.Play();
        }
    }

}
