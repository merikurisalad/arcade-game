using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite img;
    private int level;
    private int lives;
    private int score;

    public GameObject player;
    public GameObject spawner;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        // LoadLevel(0);
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        if (camera != null) {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete()
    {
        score += 1000;
        
        // TODO: create and load new level
        int nextLevel = level + 1;
        
        if (nextLevel < SceneManager.sceneCountInBuildSettings) {
            LoadLevel(nextLevel);
        } else {
            LoadLevel(0);
        }
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0) {
            NewGame();
        } else {
            LoadLevel(level);
        }
    }
}
