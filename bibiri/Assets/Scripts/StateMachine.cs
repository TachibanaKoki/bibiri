﻿using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update (){
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Clap")
        {
            animator.SetTrigger("escape");
            GetComponent<AIParamater>().escapeVector = transform.position-col.transform.position;
        }
    }
}
