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

    int _currentQuestion;
    int _currentLife;

    // Start is called before the first frame update
    void Start()
    {
        _currentQuestion = 1;
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

    void updateStatus(bool isTrue)
    {
        if (isTrue)
        {
            _currentQuestion++;
            return;
        }
        _currentLife--;
    }

    int checkStatus()
    {
        if (_currentQuestion > questions.Length)
        {
            return 1;
        }

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
}