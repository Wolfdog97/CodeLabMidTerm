using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    //public int score = 0;
    //public int highScore = 0;

	// Use this for initialization
	void Start () {
		if (instance == null) // if there is no GameManager do not destroy on load
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // if there is another GameManager... destroy yourself 
        {
            //instance.score = 0;
            Destroy(gameObject);
            return;
        }


        // Here's the normal file version
        string fullFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "SaveData.txt";
        if (File.Exists(fullFilePath))
        {
            string highScoreString = File.ReadAllText(fullFilePath);
            //highScore = int.Parse(highScoreString);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Debug.Log("Restarting Game");
    }

    public void BeginGame()
    {
        
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TitleScreen"))
        {

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }

    //public void endGame()
    //{
    //    // When the score is higher than our previous best, record a new high score.
    //    if (score > highScore)
    //    {
    //        highScore = score;

    //        // PlayerPrefs version
    //        //PlayerPrefs.SetInt("highScoreOnDisk", highScore);
    //        //PlayerPrefs.Save();

    //        // Normal file version.
    //        string fullFilePath = Application.dataPath + Path.DirectorySeparatorChar + "SaveData.txt";
    //        File.WriteAllText(fullFilePath, highScore.ToString());
    //    }
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    Debug.Log("Starting Game");
    //}

}
