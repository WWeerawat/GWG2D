using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            DontDestroyOnLoad(this.gameObject);
        }
    }
    [Header("Utils")]
    public GameObject mainMenuUI;
    public GameObject howToPlayUI;
    public GameObject loseUI;
    public GameObject winUI;
    public GameObject levelSelection;
    public int winCount;
    public GameObject endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winCount==3)
        {
            endGameUI.SetActive(true);
        }
    }
    public void GoToMainMenu() {
        mainMenuUI.SetActive(true);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        howToPlayUI.SetActive(false);
        LevelManager.Instance.KillLevel();    
    }

    public void GoToLevelSelection(){
        levelSelection.SetActive(true);
        mainMenuUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        LevelManager.Instance.KillLevel();
    }

    public void GoToHowToPlay() {
        howToPlayUI.SetActive(true);
        mainMenuUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
        LevelManager.Instance.KillLevel();    
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
