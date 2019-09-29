using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    GameObject timeText;

    public byou byouScript;
    public Text clearText;

    public float sceneTime = 10;
    public float maxSceneTime = 10;
    float getTime = 0;
    public float a = 0;

	// Use this for initialization
	void Start () {
        timeText = GameObject.Find("Time");
        byouScript = timeText.GetComponent<byou>();
        sceneTime = maxSceneTime;
	}
	
    //すぐにシーン移動しないように、少しだけとどまる
    void SceneProce()
    {
        getTime = byouScript.time;

        if (getTime == 0)
        {
            if (sceneTime > 0)
            {
                this.sceneTime -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("ClearScene");
            }
        }
    }

    //Clearテキストを表示する
    void ClearDraw()
    {
        if (sceneTime <= maxSceneTime / 2)
        {
            if(a < 1)
            {
                a += 0.1f;
                clearText.color = new Color(1, 1, 0, a);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        ClearDraw();
        SceneProce();
	}
}
