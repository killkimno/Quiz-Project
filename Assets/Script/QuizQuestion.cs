using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class QuizQuestion : MonoBehaviour {

    public QuizManager manager;

    public List<GameObject> onList = new List<GameObject>();

    public List<QuestionObject> quizObject = new List<QuestionObject>();
    public GameObject quizParent;


    public GameObject teamButtonObject;
    public GameObject nextButton;

    private QuizSlot slot;
    private int index;


    private Action<QuizSlot> callback;


    public void Show(QuizSlot slot, Action<QuizSlot> callback)
    {
        if(quizParent != null)
        {
            quizParent.SetActive(true);
        }
        this.callback = callback;
        this.gameObject.SetActive(true);
        this.slot = slot;
        for(int i = 0; i < onList.Count; i++)
        {
            onList[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < onList. Count; i++)
        {
            if(slot.answerList[i])
            {
                onList[i].gameObject.SetActive(true);
            }
        }

        for(int i = 0; i < quizObject.Count; i++)
        {
            quizObject[i].gameObject.SetActive(false);
        }

        quizObject[slot.index].gameObject.SetActive(true);
        teamButtonObject.SetActive(false);
        index = 0;
        ShowNext();
    }

    private void ShowNext()
    {
        nextButton.SetActive(true);
        List<GameObject> pageList = quizObject[slot.index].pageList;
        for (int i = 0; i < pageList.Count; i++)
        {
            pageList[i].gameObject.SetActive(false);
        }

        if(index == pageList.Count -1)
        {
            //마지막 페이지.
            pageList[pageList.Count - 1].SetActive(true);
            nextButton.SetActive(false);
            teamButtonObject.SetActive(true);
        }
        else
        {
            //페이지 남음.
            if (index < pageList.Count)
            {
                pageList[index].SetActive(true);
            }
            else
            {
                pageList[pageList.Count - 1].SetActive(true);
                nextButton.SetActive(false);
                teamButtonObject.SetActive(true);
            }

        }



    }

    public void ClickNext()
    {
        index++;
        ShowNext();
    }


    private void SetToggleObject(int index)
    {
        if(slot.answerList[index])
        {
            onList[index].SetActive(false);
        }
        else
        {
            onList[index].SetActive(true);
        }

        slot.answerList[index] = !slot.answerList[index];
    }

    public void ClickA()
    {
        SetToggleObject(0);
    }

    public void ClickB()
    {
        SetToggleObject(1);
    }

    public void ClickC()
    {
        SetToggleObject(2);
    }

    public void ClickD()
    {
        SetToggleObject(3);
    }

    public void ClickE()
    {
        SetToggleObject(4);
    }

    public void ClickF()
    {
        SetToggleObject(5);
    }

    public void ClickOK()
    {
        bool isAnswer = false;
        for(int i = 0; i < slot.answerList.Count; i++)
        {
            if(slot.answerList[i])
            {
                isAnswer = true;
                break;
            }
        }

        if(isAnswer)
        {
            slot.SetClear();
            this.gameObject.SetActive(false);
          
            if (callback != null)
            {
                callback(slot);
            }
     
        }
    }

}
