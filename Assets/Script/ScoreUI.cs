using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    public List<UILabel> scoreLabelList1 = new List<UILabel>();
    public List<UILabel> scoreLabelList2 = new List<UILabel>();
    public List<UILabel> scoreLabelList3 = new List<UILabel>();
    public List<UILabel> scoreLabelList4 = new List<UILabel>();
    public List<UILabel> scoreLabelList5 = new List<UILabel>();
    public List<UILabel> scoreLabelList6 = new List<UILabel>();


    public List<UILabel> resultScoreLabelList = new List<UILabel>();
    public List<int> totalScoreList = new List<int>();

    private List<List<int>> scoreList = new List<List<int>>();

    private List<List<UILabel>> totalLabelList = new List<List<UILabel>>();
    public void Show(List<QuizSlot> slotList, bool isResult)
    {
        totalLabelList.Clear();

        totalLabelList.Add(scoreLabelList1);
        totalLabelList.Add(scoreLabelList2);
        totalLabelList.Add(scoreLabelList3);
        totalLabelList.Add(scoreLabelList4);
        totalLabelList.Add(scoreLabelList5);
        totalLabelList.Add(scoreLabelList6);

        scoreList.Clear();

        for(int i = 0; i < 6; i++)
        {
            scoreList.Add(new List<int>());
        }

        this.gameObject.SetActive(true);

        for(int i = 0; i < totalScoreList.Count;i++)
        {
            totalScoreList[i] = 0;
        }

        for(int i = 0; i < totalLabelList.Count; i++)
        {
            for(int j = 0; j  < totalLabelList[i].Count; j++)
            {
                totalLabelList[i][j].text = "";
            }
        }

        for(int i = 0; i < slotList.Count; i++)
        {
            for(int j = 0; j < slotList[i].answerList.Count; j++)
            {
                if(slotList[i].answerList[j])
                {
                    totalScoreList[j] = totalScoreList[j] + slotList[i].score;
                    scoreList[j].Add(slotList[i].score);
                }
            }
        }

        for(int i = 0; i < scoreList.Count; i++)
        {
            for(int j = 0; j < scoreList[i].Count; j++)
            {
                if(totalLabelList[i].Count > j)
                {
                    totalLabelList[i][j].text = scoreList[i][j].ToString();
                }
                else
                {
                    totalLabelList[i][j].text = "...";
                }
            }
        }


        for(int i = 0; i < resultScoreLabelList.Count; i++)
        {
            resultScoreLabelList[i].text = totalScoreList[i].ToString();
        }
    }

    public void ClickClose()
    {
        this.gameObject.SetActive(false);
    }
}
