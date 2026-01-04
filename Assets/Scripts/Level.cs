using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    [Header("Level Utils")]
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text statusText;


    [Header("Level Detail")]
    [SerializeField] private GameObject[] questions;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private int lifeNum;

    private Queue<GameObject> questionQueue;
    GameObject _currentQuestion;
    int _currentLife = 99;
    bool isWin;

    // Start is called before the first frame update
    void Start()
    {
        questionQueue = new Queue<GameObject>(questions);
        _currentQuestion = questionQueue.Dequeue();
        _currentQuestion.SetActive(true);
        _currentLife = lifeNum;
        UpdateText();
        isWin = false;
    }

    private void Update()
    {
    }

    public void OnClick(bool isTrue)
    {
        UpdateStatus(isTrue);
        UpdateText();
    }

    public void TriggerDialogueBtn()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    public void TriggerContinueDialogueBtn()
    {
        DialogueManager.Instance.ContinueDialogue();
    }

    public void UpdateStatus(bool isTrue)
    {
        if (isTrue)
        {
            return;
        }

        _currentLife--;
    }

    public int CheckStatus()
    {
        if (isWin)
        {
            return 1;
        }

        if (_currentLife == 0)
        {
            return 0;
        }

        return -1;
    }

    public void UpdateText()
    {
        lifeText.text = " " + _currentLife + "/" + lifeNum;
    }

    public void GoNextQuestion()
    {
        if (questionQueue.Count == 0)
        {
            LevelManager.Instance.RegisterLevelClear(gameObject.name);
            isWin = true;
            return;
        }

        _currentQuestion.SetActive(false);
        _currentQuestion = questionQueue.Dequeue();
        _currentQuestion.SetActive(true);
    }
}