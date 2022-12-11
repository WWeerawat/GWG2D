using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    [Header("Level Utils")]
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text resultText;


    [Header("Level Detail")]
    [SerializeField] private List<GameObject> questions;
    [SerializeField] private int stageNum;
    [SerializeField] private int lifeNum;

    int _currentStage;
    int _currentLife;

    // Start is called before the first frame update
    void Start()
    {
        _currentStage = 1;
        _currentLife = lifeNum;
        stageText.text = "stage: " + _currentStage + "/" + stageNum;
        lifeText.text = "life: " + _currentLife + "/" + stageNum;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick(string answer)
    {
        Debug.Log("CLICK");
        if (answer == "Left")
        {
            updateStatus(true);
        }
        else
        {
            updateStatus(false);
        }
        updateText();
    }

    void updateStatus(bool isTrue)
    {
        if (isTrue)
        {
            _currentStage++;
            resultText.text = checkStatus() < 0 ? "PLAYING" : "WIN!!";
            return;
        }
        _currentLife--;
        resultText.text = checkStatus() < 0 ? "PLAYING" : "LOSE!!";
    }

    int checkStatus()
    {
        if (_currentStage > stageNum)
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
        stageText.text = "stage: " + _currentStage + "/" + stageNum;
        lifeText.text = "life: " + _currentLife + "/" + stageNum;
    }
}