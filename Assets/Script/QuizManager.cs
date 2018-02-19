using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class QuizManager : MonoBehaviour {
    public float alphaEffectValue = 0.01f;


    public ScoreUI scoreUI;
    public QuizQuestion questionUI;

    public List<QuizSlot> slotList1 = new List<QuizSlot>();
    public List<QuizSlot> slotList2 = new List<QuizSlot>();
    public List<QuizSlot> slotList3 = new List<QuizSlot>();

    public List<GameObject> currentLevelObjectList = new List<GameObject>();


    public int level1Score;
    public int level2Score;
    public int level3Score;


    public int currentLevel;
    private QuizSlot currentSlot = null;
    private List<QuizSlot> allList = new List<QuizSlot>();


    public static QuizManager instance;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            scoreUI.Show(allList);
        }
    }
    private void Awake()
    {
        instance = this;
        currentSlot = null;
        int index = 0;
        for(int i = 0; i <  slotList1.Count; i++)
        {
            slotList1[i].Init(SlotCallback, index++,0, level1Score);
            slotList1[i].SetLock();

            allList.Add(slotList1[i]);
        }

        for (int i = 0; i < slotList2.Count; i++)
        {
            slotList2[i].Init(SlotCallback, index++, 1, level2Score);
            slotList2[i].SetLock();

            allList.Add(slotList2[i]);
        }

        for (int i = 0; i < slotList3.Count; i++)
        {
            slotList3[i].Init(SlotCallback, index++, 2, level3Score);
            slotList3[i].SetLock();

            allList.Add(slotList3[i]);
        }

        for(int i = 0; i < currentLevelObjectList.Count; i++)
        {
            currentLevelObjectList[i].SetActive(false);
        }
        scoreUI.gameObject.SetActive(false);
        questionUI.gameObject.SetActive(false);

        currentLevelObjectList[0].SetActive(true);
    }

    public void SlotCallback(QuizSlot slot)
    {
        
        if (slot.level == currentLevel)
        {
            //현재 레벨
            if(slot.stateType == QuizSlot.StateType.Lock)
            {
                //현재 선택된 잠겨있는 슬롯이 없을 때만 동작.
                if(currentSlot == null)
                {
                    slot.SetOpen();
                    currentSlot = slot;
                }
            
            }
            else if(slot.stateType == QuizSlot.StateType.Clear)
            {
                questionUI.Show(slot, AnswerCallback);
            }
            else
            {
                //마지막으로 깐 슬롯과 동일할 경우에만 동작.
                if(currentSlot == slot)
                {
                    questionUI.Show(slot, AnswerCallback);
                    currentSlot = null;
                }
            
            }
        }
        else if (slot.level < currentLevel)
        {
            //이미 깬것.
        }
        else
        {
            //아직 아님.
        }
      
    }


    private void AnswerCallback(QuizSlot slot)
    {       
        if (currentLevel == slot.level)
        {
            bool isAllClear = true;

            if(currentLevel == 0)
            {
                for (int i = 0; i < slotList1.Count; i++)
                {
                    if (slotList1[i].stateType != QuizSlot.StateType.Clear)
                    {
                        isAllClear = false;
                        break;
                    }
                }
            }
            else if(currentLevel == 1)
            {
                for (int i = 0; i < slotList2.Count; i++)
                {
                    if (slotList2[i].stateType != QuizSlot.StateType.Clear)
                    {
                        isAllClear = false;
                        break;
                    }
                }
            }
            else if(currentLevel == 2)
            {
                for (int i = 0; i < slotList3.Count; i++)
                {
                    if (slotList3[i].stateType != QuizSlot.StateType.Clear)
                    {
                        isAllClear = false;
                        break;
                    }
                }
            }

            if(isAllClear)
            {
                currentLevel++;

                for(int i = 0; i < currentLevelObjectList.Count; i++)
                {
                    currentLevelObjectList[i].SetActive(false);
                }

                if(currentLevel < currentLevelObjectList.Count)
                {
                    currentLevelObjectList[currentLevel].SetActive(true);
                }
               
            }
          
        }

 
    }
}
