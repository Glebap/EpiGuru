using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private Player _player; 
    [SerializeField] private TMP_Text _pointsText; 
    [SerializeField] private GameObject _gameOverUI; 
    [SerializeField] private TMP_Text _finalScoreText; 

    [Header("UI Buttons")]
    [SerializeField] private Button _pauseButton; 
    [SerializeField] private Button _quitButton; 
    [SerializeField] private Button _closeGameOverButton; 

    private int _points;
    private bool _isGamePaused;
    private bool _isGameFinished;

    
    private void Start()
    {
        _isGamePaused = false;
        _gameOverUI.SetActive(false);
        
        _pauseButton.onClick.AddListener(TogglePause);
        _quitButton.onClick.AddListener(QuitGame);
        _closeGameOverButton.onClick.AddListener(CloseGame);

        _player.TriggerEntered += OnPlayerTriggerEnter;
    }

    private void OnPlayerTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
            EndGame();
        else if (other.CompareTag("Coin"))
            CollectCoin(other.gameObject);
    }

    private void CollectCoin(Object coin)
    {
        _points++;
        _pointsText.text = _points + " points";
        Destroy(coin);
    }

    private void EndGame()
    {
        _gameOverUI.SetActive(true);
        _finalScoreText.text = $"YOU SCORE {_points} POINTS!";
        Time.timeScale = 0;
    }

    private void TogglePause()
    {
        if (_isGamePaused)
        {
            Time.timeScale = 1;
            _isGamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            _isGamePaused = true;
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void CloseGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Bootstrap");
    }
}
