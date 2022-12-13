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

    [SerializeField] private Queue<GameObject> questionQueue;
    GameObject _currentQuestion;
    int _currentLife;

    // Start is called before the first frame update
    void Start()
    {
        questionQueue = new Queue<GameObject>(questions);
        _currentQuestion = questionQueue.Dequeue();
        _currentQuestion.SetActive(true);
        _currentLife = lifeNum;
        updateText();
    }

    private void Update()
    {
    }

    public void OnClick(bool isTrue)
    {
        updateStatus(isTrue);
        updateText();
    }

    public void TriggerDialogueBtn()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
    public void TriggerContinueDialogueBtn()
    {
        DialogueManager.Instance.ContinueDialogue();
    }

    void updateStatus(bool isTrue)
    {
        if (isTrue)
        {
            return;
        }
        _currentLife--;
    }

    int checkStatus()
    {
        // if (_currentQuestion > dialogue.sentences.Length)
        // {
        //     return 1;
        // }

        if (_currentLife == 0)
        {
            return 0;
        }
        return -1;
    }

    void updateText()
    {
        string status = checkStatus() > 0 ? "WIN" : checkStatus() == 0 ? "LOSE" : "SELECTION";
        statusText.text = "status: " + status;
        lifeText.text = "life: " + _currentLife + "/" + lifeNum;
    }

    public void GoNextQuestion()
    {
        _currentQuestion.SetActive(false);
        _currentQuestion = questionQueue.Dequeue();
        _currentQuestion.SetActive(true);
    }
}