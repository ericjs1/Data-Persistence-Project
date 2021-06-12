using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        bestScoreText.text = "Best Score: " + GameManager.Instance.BestScoreName + " " + GameManager.Instance.BestScore;
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
        GameManager.Instance.CurrentName = nameField.text;
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveBestScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
