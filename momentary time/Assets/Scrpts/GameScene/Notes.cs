using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour {
    GameObject MGauge;
    public MomentaryGauge MGaugeScript;

    public float notesSpeed = 0.05f;
    float DefNSpeed = 0.05f;
    float MSpeed = 0.035f;
    public float frameOut = -9;

    bool GetMTIme = false;

    // Use this for initialization
    void Start()
    {
        MGauge = GameObject.Find("MomentaryGauge");
        MGaugeScript = MGauge.GetComponent<MomentaryGauge>();
    }

    //ノーツの移動と削除
    void Move()
    {
        transform.Translate(-this.notesSpeed, 0, 0);

        if (transform.position.x < frameOut)
        {
            Destroy(gameObject);
        }
    }

    //MomentaryTimeに入った、ノーツの処理
    void TrueMTime()
    {
        GetMTIme = MGaugeScript.MTime;

        if (GetMTIme)
        {
            notesSpeed = MSpeed;
        }

        if(!GetMTIme)
        {
            notesSpeed = DefNSpeed;
        }
    }
    
    // Update is called once per frame
    void Update () {
        TrueMTime();
        Move();
	}
}
