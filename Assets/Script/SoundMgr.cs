using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public enum SoundType
    {
        None, SlotOpen, SlotEnter, Fortune, question_name, sound_buttion_right, sound_buttion_wrong, answer_confirm,
    };

    public static SoundMgr instance;

    public AudioSource clickSound;
    public AudioSource openSound;
    public AudioSource fortuneSound;
    public AudioSource question_name;
    public AudioSource sound_buttion_right;
    public AudioSource sound_buttion_wrong;
    public AudioSource answer_confirm;

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
        else if(soundType == SoundType.Fortune)
        {
            instance.fortuneSound.Play();
        }
        else if(soundType == SoundType.question_name)
        {
            instance.question_name.Play();
        }
        else if(soundType == SoundType.sound_buttion_right)
        {
            instance.sound_buttion_right.Play();
        }
        else if(soundType == SoundType.sound_buttion_wrong)
        {
            instance.sound_buttion_wrong.Play();
        }
        else if (soundType == SoundType.answer_confirm)
        {
            instance.answer_confirm.Play();
        }
    }

}
