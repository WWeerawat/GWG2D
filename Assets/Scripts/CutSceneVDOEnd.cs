using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Net.NetworkInformation;
using UnityEngine.SceneManagement;

public class CutSceneVDOEnd : MonoBehaviour

{
    public VideoPlayer videoPlayer;

    [SerializeField] private string nextSceneName;
    public GameObject continueButton;

    void Start()
    {
        continueButton.SetActive(false);
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            skip();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }


    private void skip()
    {
        continueButton.GetComponent<Button>().onClick.Invoke();
    }


    // Called when the video finishes
    void EndReached(VideoPlayer vp)
    {
        Debug.Log("Cutscene ended!");
        continueButton.SetActive(true);
    }
}
