using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionScript : MonoBehaviour {
    GameObject HitZorn;
    GameObject Decision;

    int getDecision = 0;

    public HitController HitCon;
    public Text DecisionTx;

    // Use this for initialization
    void Start () {
        HitZorn = GameObject.Find("HitZorn");
        Decision = GameObject.Find("Decision");

        HitCon = HitZorn.GetComponent<HitController>();
        DecisionTx = Decision.GetComponent<Text>();
    }

    //受け取ったゲームの判定を表示する
    void DrowDecision()
    {
        getDecision = HitCon.decision;

        switch (getDecision)
        {
            case 1:
                DecisionTx.color = new Color(100f / 255f, 100f / 255f, 100f / 255f);
                DecisionTx.text = "Bad";
                break;

            case 2:
                DecisionTx.color = new Color(0f / 255f, 200f / 255f, 0f / 255f);
                DecisionTx.text = "Good";
                break;

            case 3:
                DecisionTx.color = new Color(255f / 255f, 200f / 255f, 0f / 255f);
                DecisionTx.text = "Excellent";
                break;

            case 4:
                DecisionTx.color = new Color(200f / 255f, 200f / 255f, 0f / 255f);
                DecisionTx.text = "Perfect";
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        DrowDecision();
    }
}
