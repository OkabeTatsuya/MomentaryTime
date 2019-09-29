using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
    public Image pushKeyImage;

    float a;
    bool up;

	// Use this for initialization
	void Start () {
        a = 0;
	}
	
    void PushKeyDraw()
    {
        pushKeyImage.color = new Color(1, 1, 1, a);

        if (up)
        {
            a -= Time.deltaTime;
        }
        else
        {
            a += Time.deltaTime;
        }

        if(a < 0)
        {
            a = 0;
            up = false;
        }
        else if(a > 1)
        {
            a = 1;
            up = true;
        }
    }

	// Update is called once per frame
	void Update () {
        PushKeyDraw();
    }
}
