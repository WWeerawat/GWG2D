using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get { return _instance; } }
    private static LevelManager _instance;

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
    [SerializeField] private GameObject instantiateParent;
    [SerializeField] private GameObject LevelSelection;
    
    [Header("Levels")]
    [SerializeField] private GameObject[] levels;
    // [SerializeField] private Level currentLevel;

    Level currentLevel;
    private void Start() {
        
    }

    private void Update() {
        if (currentLevel != null) {
            if (currentLevel.checkStatus()==0)
        {
            GameManager.Instance.loseUI.SetActive(true);
        }
            else if(currentLevel.checkStatus()==1)
        {
            if (GameManager.Instance.winCount<3)
            {
                GameManager.Instance.winUI.SetActive(true);
            }
        }
        }
        
    }
    public void GoNextQuestion()
    {
        currentLevel.GoNextQuestion();
    }

    public void SelectLevel(string levelName)
    {
        GameObject level = levels.FirstOrDefault(level => level.name == levelName);
        if (level == null)
        {
            Debug.LogError("Level not found");
            return;
        }
        GameObject levelObj = Instantiate(level, instantiateParent.transform);
        levelObj.SetActive(true);
        currentLevel = levelObj.GetComponent<Level>();
        LevelSelection.SetActive(false);
    }
    public void KillLevel(){
        
        if (currentLevel != null){
            DestroyImmediate(currentLevel.transform.gameObject);
        }
    }
}