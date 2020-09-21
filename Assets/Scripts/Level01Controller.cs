using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;

    private int _currentScore;
    private string highscoreString = "HighScore";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt(highscoreString);
        if(_currentScore > highScore)
        {
            //save new high score
            PlayerPrefs.SetInt(highscoreString, _currentScore);
            Debug.Log("New High Score: " + _currentScore);
        }

        //go to main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;

        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }
}
