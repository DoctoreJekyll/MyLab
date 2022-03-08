using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller00 : MonoBehaviour
{

    public int health;
    public float score;
    public GameObject player;

    public TMP_Text scoreTxt;
    public TMP_Text healthTxt;

    // Update is called once per frame
    void Update()
    {

        ShowValues();

        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeHealth(1);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeHealth(-1);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeScore(10f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeScore(-10f);
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadGame();
        }


    }

    public void SaveGame()
    {
        SaveManager.SaveGameData(this);
    }

    public void LoadGame()
    {
        GameData gameData = SaveManager.LoadGameData();
        health = gameData.playerHealth;
        score = gameData.playerScore;
        player.transform.position = new Vector3(gameData.playerPos[0], gameData.playerPos[1], gameData.playerPos[2]);
    }


    public void ShowValues()
    {
        healthTxt.text = "HEALTH: " + health;
        scoreTxt.text = "SCORE: " + score;
    }


    public void ChangeHealth(int amount)
    {
        health += amount;
        
    }

    public void ChangeScore(float scoreAmount)
    {
        score += scoreAmount;
    }




}
