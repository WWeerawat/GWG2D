using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class EndingStory : MonoBehaviour

{
    public VideoPlayer videoPlayer;
    public GameObject quitButton;

    void Start()
    {
        quitButton.SetActive(false);
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    // Called when the video finishes
    void EndReached(VideoPlayer vp)
    {
        Debug.Log("Cutscene Ending ended!");
        quitButton.SetActive(true);
    }
}
