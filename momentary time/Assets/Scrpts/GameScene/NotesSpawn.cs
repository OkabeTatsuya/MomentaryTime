using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesSpawn : MonoBehaviour {
    public GameObject NotesPrefab;
    public GameObject BlockPrefab;
    GameObject timeTxt;

    public int nowPattern = 0;

    public int pattern1 = 0;
    public int pattern2 = 0;
    public int pattern3 = 0;

    public int timing1 = 0;
    public int timing2 = 0;
    public int timing3 = 0;

    float delta = 0;
    float getTime = 0;

    public byou byouScript;

    // Use this for initialization
    void Start () {
        timeTxt = GameObject.Find( "Time" );
        byouScript = timeTxt.GetComponent<byou>();
	}

    //ノーツのスポーン処理

    // Patternごとの処理
    void Pattern1()
    {
        delta += Time.deltaTime;

        if (this.delta > this.pattern1)
        {
            this.delta = 0;
            Instantiate(NotesPrefab);
            Instantiate(BlockPrefab);
        }
    }

    void Pattern2()
    {
        delta += Time.deltaTime;

        if (this.delta > this.pattern2)
        {
            this.delta = 0;
            Instantiate(NotesPrefab);
            Instantiate(BlockPrefab);
        }
    }

    void Pattern3()
    {
        delta += Time.deltaTime;

        if (this.delta > this.pattern3)
        {
            this.delta = 0;
            Instantiate(NotesPrefab);
            Instantiate(BlockPrefab);
        }
    }

    void SpanSwitch()
    {
        switch(nowPattern)
        {
            case 1:
                Pattern1();
                break;

            case 2:
                Pattern2();
                break;

            case 3:
                Pattern3();
                break;

            default:
                break;
        }
    }

    void Spawn()
    {
        getTime = byouScript.time;

        if (getTime <= timing1)
        {
            nowPattern = 1;
        }

        if (getTime <= timing2)
        {
            nowPattern = 2;
        }

        if (getTime <= timing3)
        {
            nowPattern = 3;
        }

        if(getTime <= 0)
        {
            nowPattern = 0;
        }

        SpanSwitch();
    }
    // Update is called once per frame
    void Update () {
        Spawn();
	}
}
