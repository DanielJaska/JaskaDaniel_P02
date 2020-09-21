using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;

    // Start is called before the first frame update
    void Start()
    {
        //load score
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

       if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        } 
    }

    public void ResetScoreData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        _highScoreTextView.text = "0";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
