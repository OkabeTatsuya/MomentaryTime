using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {
    GameObject Score;
    GameObject HitZorn;

    public float gameScore = 0;
    public int pScore = 1000;
    public int eScore = 500;
    public int gScore = 250;
    public int bScore = 100;

    int inCount = 0;
    int getDecision = 0;

    public bool endScore = false;

    public HitController HitCon;
    public Text ScoreTx;

    // Use this for initialization
    void Start() {
        Score = GameObject.Find("Score");
        HitZorn = GameObject.Find("HitZorn");

        HitCon = HitZorn.GetComponent<HitController>();
        ScoreTx = Score.GetComponent<Text>();
    }

    //判定によってスコアの上昇量を決める、処理の終了判定
    void PlusScore()
    {
        getDecision = HitCon.decision;

        switch(getDecision)
        {
            case 1:
                gameScore += bScore;
                inCount++;
                endScore = true;
                break;

            case 2:
                gameScore += gScore;
                inCount++;
                endScore = true;
                break;

            case 3:
                gameScore += eScore;
                inCount++;
                endScore = true;
                break;

            case 4:
                gameScore += pScore;
                inCount++;
                endScore = true;
                break;

            default:
                endScore = false;
                break;
        }
    }

    //スコアを更新する
    void InCount()
    {
        if (!endScore)
        {
            inCount = 0;
        }

        if (inCount == 0)
        {
            PlusScore();
            ScoreTx.text = this.gameScore.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
        InCount();
    }
}
