
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreSceneManager : MonoBehaviour
{
    public TMP_Text Text;
    private void Start()
    {
       int score = PlayerPrefs.GetInt("Score");
       Text.text = "Congratulations, you have completed the test with a score of "+ score + "\nThank you for playing.";
    }
    public void RePlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
   {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
   }
}
