using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MyMonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance { get => instance; }
    private bool menuOpen;
    public Transform Menu;
    public bool gamestarted;
    public TMP_Text gameStartText;
    public TMP_Text CurrentScore;
    public TMP_Text PreScore;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.Log("Only 1 ObjectSpawner allow");
        GameManager.instance = this;
    }
    protected override void Start()
    {
        PreScore.text = "Previous Score : " + SaveScore.Instance.LoadScore().ToString();
        base.Start();
        Menu.gameObject.SetActive(false);
        menuOpen =false;
        StartCoroutine(GameStart());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenCloseMenu();
        }
    }

    IEnumerator GameStart()
    {
        gameStartText.text = "Game Start in 5s, ESC to pause, WASD to move,\nShift to Sprint, Space to Jump";
        yield return new WaitForSeconds(1f);
        gameStartText.text = "Game Start in 4s, ESC to pause, WASD to move,\nShift to Sprint, Space to Jump";
        yield return new WaitForSeconds(1f);
        gameStartText.text = "Game Start in 3s, ESC to pause, WASD to move,\nShift to Sprint, Space to Jump";
        yield return new WaitForSeconds(1f);
        gameStartText.text = "Game Start in 2s, ESC to pause, WASD to move,\nShift to Sprint, Space to Jump";
        yield return new WaitForSeconds(1f);
        gameStartText.text = "Game Start in 1s, ESC to pause, WASD to move,\nShift to Sprint, Space to Jump";
        yield return new WaitForSeconds(1f);
        gameStartText.text = "GAME START";
        yield return new WaitForSeconds(1f);
        gameStartText.text = "";
        gamestarted = true;
    }
    public virtual void Pause()
    {
        Time.timeScale = 0f;
    }

    public virtual void Continue()
    {
        Time.timeScale = 1f;
    }

    public virtual void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void GameOver()
    {
        gamestarted = false;
        gameStartText.text = "GAME OVER";
        int currentscore = PlayerPrefs.GetInt("Score");
        SaveScore.Instance.SaveScoretoJson(currentscore);
        SceneManager.LoadScene("ScoreScene");
    }

    public virtual void UpdateScore(int score) 
    {
        CurrentScore.text = "Score: " + score;
        PlayerPrefs.SetInt("Score", score);
    }
    public void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
    public virtual void OpenCloseMenu() 
    {
        if (menuOpen)
        {
            Menu.gameObject.SetActive(false);
            menuOpen = false;
            Continue();
        }
        else
        {
            Menu.gameObject.SetActive(true);
            menuOpen = true;
            Pause();
        }
    }
}
