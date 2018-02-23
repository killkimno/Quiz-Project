using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class QuizSlot : MonoBehaviour {

    public enum StateType
    {
        Lock, Opening, Ready, Clear,
    }



    public UILabel titleLabel;
    
    public UIWidget lockObject;
    public GameObject opendObject;
    public GameObject clearObject;

    public UIGrid answerGrid;
    public List<GameObject> answerObjectList = new List<GameObject>();


    public int index;
    public int level;
    public int score;

    public List<bool> answerList = new List<bool>();

    public StateType stateType = StateType.Lock;
    public Action<QuizSlot> callback;


    public void SetLock()
    {
        lockObject.gameObject.SetActive(true);
        opendObject.SetActive(false);
    }

    public void SetOpen()
    {
        StartCoroutine(ProcessOpen());
        opendObject.SetActive(true);
        clearObject.SetActive(false);
       
    }

    IEnumerator ProcessOpen()
    {
        stateType = StateType.Opening;
        while (lockObject.alpha > 0)
        {
            lockObject.alpha = lockObject.alpha - QuizManager.instance.alphaEffectValue;
            yield return null;
        }

        lockObject.alpha = 0;
        stateType = StateType.Ready;
        yield break;
    }

    public void SetClear()
    {
        clearObject.SetActive(true);
        stateType = StateType.Clear;

        if (answerGrid != null)
        {
            for (int i = 0; i < answerObjectList.Count && i < answerList.Count; i++)
            {
                answerObjectList[i].gameObject.SetActive(answerList[i]);
            }

            answerGrid.repositionNow = true;
            answerGrid.Reposition();
        }
    }

    public void Init(Action<QuizSlot> callback,  int index, int level, int score)
    {
        if(answerGrid != null)
        {
            for(int i = 0; i < answerObjectList.Count; i++)
            {
                answerObjectList[i].gameObject.SetActive(false);
            }
        }
        this.score = score;
        this.index = index;
        this.level = level;
        this.callback = callback;

        answerList.Clear();

        answerList.Add(false);
        answerList.Add(false);
        answerList.Add(false);
        answerList.Add(false);
        answerList.Add(false);
        answerList.Add(false);
    }

    public void ClickSlot()
    {
        if(stateType == StateType.Opening)
        {
            return;
        }
        if(stateType == StateType.Lock)
        {
            SoundMgr.PlaySound(SoundMgr.SoundType.SlotOpen);
        }
        else if(stateType == StateType.Ready)
        {
            SoundMgr.PlaySound(SoundMgr.SoundType.SlotEnter);
        }
        
        if (callback != null)
        {
            callback(this);
        }
    }

}
