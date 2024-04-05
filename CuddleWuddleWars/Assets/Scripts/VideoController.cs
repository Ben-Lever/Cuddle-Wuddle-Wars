using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Canvas tutorialCanvas;

    void Start()
    {
        // Get the VideoPlayer attached to this GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Register for when the video playback is finished
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        tutorialCanvas.gameObject.SetActive(true);
    }
}
