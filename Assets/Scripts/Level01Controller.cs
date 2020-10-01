using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject _pauseMenu;

    private int _currentScore;
    private string highscoreString = "HighScore";

    //private bool isPaused = false;

    private void Start()
    {
        TogglePauseState(GameManager.PlayerState.Playing);
    }

    public void TogglePauseState(GameManager.PlayerState newState)
    {
        GameManager.playerState = newState;
        if(GameManager.playerState != GameManager.PlayerState.Playing)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if(GameManager.playerState == GameManager.PlayerState.Playing)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Unpause()
    {
        TogglePauseState(GameManager.PlayerState.Playing);
    }

    // Update is called once per frame
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Q) && isPaused != true)
        //{
        //    IncreaseScore(5);
        //}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.playerState == GameManager.PlayerState.Playing)
            {
                TogglePauseState(GameManager.PlayerState.Paused);
            } else if(GameManager.playerState == GameManager.PlayerState.Paused)
            {
                TogglePauseState(GameManager.PlayerState.Playing);
            }
            

            //ExitLevel();
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
