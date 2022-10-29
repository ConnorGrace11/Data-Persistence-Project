using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField input;
    public TextMeshProUGUI highScore;
    public static string userName;


    // Start is called before the first frame update
    void Start()
    {
        MenuManager.Instance.LoadHighScore();
        Debug.Log(MenuManager.Instance.user);
        Debug.Log(MenuManager.Instance.highScore);
        highScore.SetText($"Best Score: {MenuManager.Instance.user}: {MenuManager.Instance.highScore}");
        input.onEndEdit.AddListener(SubmitName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNow()
    {
        //MenuManager.Instance.SaveHighScore();
        MenuManager.Instance.LoadHighScore();
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SubmitName(string arg0)
    {
        MenuManager.Instance.user = arg0;
        userName = arg0;
    }
}
