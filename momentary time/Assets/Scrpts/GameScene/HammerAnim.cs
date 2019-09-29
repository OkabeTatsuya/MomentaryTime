using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAnim : MonoBehaviour {
    public Animator animator;

	// Use this for initialization
	void Start () {
	}

    //スペースキーが押されたらアニメーションを再生する
    void HitAnim()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {         
            this.animator.SetBool("IsHit", true);
        }
        else
        {
            this.animator.SetBool("IsHit", false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        HitAnim();
	}
}
