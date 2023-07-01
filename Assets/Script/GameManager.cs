using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _singleton;
    public int _currentScore = 0;
    public int _quitScore = 3;
    public GameObject _panelGameOver;
    public Text _panelText;
    public Text _scoreText;

    private void Awake()
    {
        if (_singleton == null)
        {
            _singleton = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetScore()
    {
        _currentScore += 1;
        _scoreText.text = _currentScore.ToString();
        if (_currentScore >= _quitScore)
        {
            _panelGameOver.SetActive(true);
            _panelText.text = "WIN";
        }
    }

    public void GameFail()
    {
        _panelGameOver.SetActive(true);
        _panelText.text = "Game Over";
    }

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
