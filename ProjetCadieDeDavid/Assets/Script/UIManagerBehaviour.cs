﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIManagerBehaviour : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selection;
    public GameObject HUD;
    public GameObject pause;
    public GameObject gameOver;

    public Text levelText;
    public Text coinText;
    public TMP_Text[] listHUDText;
    public TMP_Text[] listNumberHUDText;
    public GameObject[] miniatureArtcileArray;
    public Color32 red;
    public Color32 orange;
    public Color32 green;

    private static UIManagerBehaviour _instance;
    public static UIManagerBehaviour instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        for(int i = 0; i < miniatureArtcileArray.Length; i++)
        {
            miniatureArtcileArray[i].GetComponent<Image>().preserveAspect = true;
            miniatureArtcileArray[i].SetActive(false);
        }
        red.a = 255;
        orange.a = 255;
        green.a = 255;
    }
    public void SetMainMenuActive()
    {
        mainMenu.SetActive(true);
        selection.SetActive(false);
        HUD.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
    }
    public void SetLevelSelectionActive()
    {
        mainMenu.SetActive(false);
        selection.SetActive(true);
        HUD.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
    }
    public void SetHUDActive()
    {
        mainMenu.SetActive(false);
        selection.SetActive(false);
        HUD.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
    }
    public void SetPauseActive()
    {
        mainMenu.SetActive(false);
        selection.SetActive(false);
        HUD.SetActive(false);
        pause.SetActive(true);
        gameOver.SetActive(false);
        LevelManagerBehaviour.Instance.DisplayList();
        LevelManagerBehaviour.Instance.menuBriefing.SetActive(true);
    }
    public void SetGameOverActive()
    {
        mainMenu.SetActive(false);
        selection.SetActive(false);
        HUD.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(true);
    }
    public void SetRecipeActive()
    {
        mainMenu.SetActive(false);
        selection.SetActive(false);
        HUD.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
    }

    public void DisplayLevel()
    {
        levelText.text = "Level : " + LevelManagerBehaviour.Instance.level;
    }
    public void DisplayCoin()
    {
        coinText.text = "Coin : " + GameManagerBehaviour.instance.coin;
    }
    public void DisplayListHUD()
    {
        for (int i = 0; i < LevelManagerBehaviour.Instance.articleCurrentList.Count; i++)
        {
            miniatureArtcileArray[i].SetActive(true);
            miniatureArtcileArray[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(LevelManagerBehaviour.Instance.articleCurrentList[i]);
            listHUDText[i].text = LevelManagerBehaviour.Instance.articleCurrentList[i];
            if (i >= LevelManagerBehaviour.Instance.articleAskedArray.Length)
            {
                listHUDText[i].color = red;
            }
            else
            {
                if (LevelManagerBehaviour.Instance.articleCurrentNumberList[i] == LevelManagerBehaviour.Instance.articleNumberArray[i])
                {
                    listHUDText[i].color = green;
                }
                else if (LevelManagerBehaviour.Instance.articleCurrentNumberList[i] > LevelManagerBehaviour.Instance.articleNumberArray[i])
                {
                    listHUDText[i].color = orange;
                }
            }
            listNumberHUDText[i].SetText(LevelManagerBehaviour.Instance.articleCurrentNumberList[i].ToString());
            if (i < LevelManagerBehaviour.Instance.articleNumberArray.Length)
            {
                listNumberHUDText[i].text += "/" + LevelManagerBehaviour.Instance.articleNumberArray[i].ToString();
            }
        }
    }
}
