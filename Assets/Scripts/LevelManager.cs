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
    [Header("Levels")]
    [SerializeField] private GameObject[] levels;
    [SerializeField] private Level currentLevel;

    // Level currentLevel;
    public void GoNextQuestion()
    {
        currentLevel.GoNextQuestion();
        DialogueManager.Instance.EndDialogue();
    }

    public void SelectLevel(string levelName)
    {
        GameObject level = levels.FirstOrDefault(level => level.name == levelName);
        Instantiate(level, instantiateParent.transform);
        currentLevel = level!.GetComponent<Level>();
    }
}