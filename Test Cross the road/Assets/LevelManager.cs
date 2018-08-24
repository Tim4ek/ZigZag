using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager levelManager;
    private int steps;
    public int stepsToCreateMoreLanes = 12;
    private int currenrSteps;
    public Text stepText;
    public Text gameOverText;

	// Use this for initialization
	void Awake () {
        levelManager = this;
	}

    public void SetSteps()
    {
        steps++;
        stepText.text = steps.ToString();
        currenrSteps++;
        if(currenrSteps > stepsToCreateMoreLanes)
        {
            currenrSteps = 0;
            GetComponent<LevelCreator>().CreateLanes();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over \nPoints: " + steps.ToString();
        Invoke("ReloadScene", 2f);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }	
	
}
