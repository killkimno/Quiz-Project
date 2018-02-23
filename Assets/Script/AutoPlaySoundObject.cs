using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlaySoundObject : MonoBehaviour {

    public SoundMgr.SoundType soundType;



    private void OnEnable()
    {
        SoundMgr.PlaySound(soundType);
    }
}
