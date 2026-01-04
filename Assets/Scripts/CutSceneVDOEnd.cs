using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class CutSceneVDOEnd : MonoBehaviour

{
    public VideoPlayer videoPlayer;
    public GameObject continueButton;

    void Start()
    {
        continueButton.SetActive(false);
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    // Called when the video finishes
    void EndReached(VideoPlayer vp)
    {
        Debug.Log("Cutscene ended!");
        continueButton.SetActive(true);
    }
}
