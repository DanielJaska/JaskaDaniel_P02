using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _playerHealth = 100;
    private int _currentPlayerHealth = 100;
    [SerializeField] Image _playerHealthText;
    [SerializeField] AudioSource playerHurt;
    [SerializeField] AudioSource playerLose;

    [SerializeField] GameObject loseMenu;

    public enum PlayerState
    {
        Playing,
        Win,
        Lose,
        Paused
    }

    public static PlayerState playerState = PlayerState.Playing;

    public void TakeDamage(int damageDelt)
    {
        _currentPlayerHealth -= damageDelt;
        float percent = (float)_currentPlayerHealth / (float)_playerHealth;
        _playerHealthText.transform.localScale = new Vector3(percent, 1f, 1f);
        playerHurt.Play();
        if(_currentPlayerHealth <= 0)
        {
            playerLose.Play();
            LoseGame();
        }
    }

    public bool CheckMaxHealth()
    {
        if(_currentPlayerHealth == _playerHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void LoseGame()
    {
        playerState = PlayerState.Lose;
        loseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Level01");
    }
}
