using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public enum SoundType
    {
        None, SlotOpen, SlotEnter,
    };

    public static SoundMgr instance;

    public AudioSource clickSound;
    public AudioSource openSound;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySound(SoundType soundType)
    {
        if(soundType == SoundType.SlotOpen)
        {
            instance.clickSound.Play();
        }
        else if(soundType == SoundType.SlotEnter)
        {
            instance.openSound.Play();
        }
    }

}
