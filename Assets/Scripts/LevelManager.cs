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
        }
    }


    [Header("Utils")]
    [SerializeField] private GameObject instantiateParent;
    [SerializeField] private GameObject LevelSelection;

    [Header("Levels")]
    [SerializeField] private GameObject[] levels;
    private HashSet<string> clearedLevels = new HashSet<string>();
    Level currentLevel;

    private void Start()
    {

    }

    private void Update()
    {
        if (currentLevel != null)
        {
            if (currentLevel.CheckStatus() == 0)
            {
                GameManager.Instance.loseUI.SetActive(true);
            }
            else if (currentLevel.CheckStatus() == 1)
            {
                GameManager.Instance.winUI.SetActive(true);
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

    public void KillLevel()
    {
        if (currentLevel != null)
        {
            DestroyImmediate(currentLevel.transform.gameObject);
        }
    }

    public void RegisterLevelClear(string levelName)
    {
        clearedLevels.Add(levelName);

        if (clearedLevels.Count >= levels.Length)
        {
            GameManager.Instance.ShowEndGameUI();
        }
    }

}