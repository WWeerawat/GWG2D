using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return; //Avoid doing anything else
        }
        if (_instance == null)
        {
            _instance = this;
        }
    }
    [Header("Utils")]
    public string mainMenuSceneName;
    public GameObject howToPlayUI;
    public GameObject loseUI;
    public GameObject winUI;
    public GameObject levelSelection;

    public GameObject endGameUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void GoToLevelSelection()
    {
        levelSelection.SetActive(true);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        LevelManager.Instance.KillLevel();
    }

    public void ResetLevelSelection()
    {
        Destroy(levelSelection);
        Instantiate(levelSelection);
        levelSelection.SetActive(true);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        LevelManager.Instance.KillLevel();
    }

    public void GoToHowToPlay()
    {
        howToPlayUI.SetActive(true);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        LevelManager.Instance.KillLevel();
    }


    public void ShowEndGameUI()
    {
        howToPlayUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        LevelManager.Instance.KillLevel();
        endGameUI.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
