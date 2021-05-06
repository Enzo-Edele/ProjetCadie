﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerBehaviour : MonoBehaviour
{
    public int level;
    public bool levelDone;

    public float backgroundSpeed;
    public int capaciteCaddie;

    public int minSpeed;
    public int maxSpeed;
    public int minTime;
    public int maxTime;

    public int playerLife;

    public string[] recette = new string[0];

    public GameObject menuBriefing;
    public Image imageArticle;
    public Text articleName;
    public Sprite[] article;
    int articlePos = 0;

    public enum LevelStates
    {
        LevelBriefing,
        Collect,
        Run,
    }
    private static LevelStates _LevelState;
    public static LevelStates LevelState
    {
        get
        {
            return _LevelState;
        }
    }
    private static LevelManagerBehaviour _instance;
    public static LevelManagerBehaviour instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        ChangeLevelStates(LevelStates.LevelBriefing);
        //listetexte (recette[1] "saut de ligne" recette[2])
    }
    private void Start()
    {
        UIManagerBehaviour.instance.DisplayLevel();
        UIManagerBehaviour.instance.DisplayListHUD();
        imageArticle.preserveAspect = true;
        ChangeSprite(0);
    }

    public void ChangeLevelStates(LevelStates currentState)
    {
        _LevelState = currentState;
        switch(_LevelState)
        {
            case LevelStates.LevelBriefing:
                UIManagerBehaviour.instance.HUD.SetActive(false);
                menuBriefing.SetActive(true);
                Time.timeScale = 0;
                break;
            case LevelStates.Collect:
                UIManagerBehaviour.instance.HUD.SetActive(true);
                menuBriefing.SetActive(false);
                Time.timeScale = 1;
                break;
            case LevelStates.Run:
                UIManagerBehaviour.instance.HUD.SetActive(true);
                menuBriefing.SetActive(false);
                Time.timeScale = 1;
                break;
        }
    }

    //Button
    public void ChangeLevelStatebyUI(int levelState)
    {
        switch (levelState)
        {
            case 1:
                ChangeLevelStates(LevelManagerBehaviour.LevelStates.Collect);
                break;
            case 2:
                ChangeLevelStates(LevelManagerBehaviour.LevelStates.Run);
                break;
        }
    }

    public void ChangeSprite(int amount)
    {
        if(articlePos + amount >= 0 && articlePos + amount < article.Length)
        {
            articlePos += amount;
            imageArticle.sprite = article[articlePos];
            articleName.text = article[articlePos].name;
        }
    }
}
