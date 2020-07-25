using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    public static GameState Instance => instance;
    public List<Rating> levelRatings = new List<Rating>();

    private void Awake()
    {
        // scenes which are no levels should not be taken into account.
        // adjust in editor when non-levels are added to the build-settings
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings - 3; i++)
        {
            levelRatings.Add(Rating.Unfinished);
        }


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevelRating(int level, Rating rating)
    {
        levelRatings[level] = rating;
    }
}
