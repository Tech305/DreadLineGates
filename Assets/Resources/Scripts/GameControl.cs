﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static List<Func<bool, string>> functionList = new List<Func<bool, string>>();
    public static  GameControl inst;
    internal static Client client;

    // Use this for initialization
    void Start () {
	    if(!inst)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(inst)
        {
            if (inst != this)
                Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    for(int i = 0; i < functionList.Count; i++)
        {
            Debug.Log(functionList[i](true));
            functionList.RemoveAt(i);
        }
	}

    void OnLevelWasLoaded(int lev)
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Connection":
                UILabel infolable = GameObject.Find("infolable").GetComponent<UILabel>();
                StartCoroutine(FUNCTIONS.ConnectToServer(infolable));
                break;
            case "Login":

                break;
        }
    }
   
}