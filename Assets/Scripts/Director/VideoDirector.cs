using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoDirector : MonoBehaviour {
    [Header("Pointers")]
    public DirectorUI pCUI;
    public VRInterface pCInterface;
    private VideoSelectionUI[] videosList;
    public RenderTexture rendTex;
    [Space]
    public Image playPause;
    public Sprite play;
    public Sprite pause;

    [Header("Content")]
    public VideoObject curVideo;
    public VideoObject[] Videos;
    public Material[] videoMats;

    private void Awake() {
        videosList = populateUIList();
    }

    private void Start() {
        ChangeVideo(0);
    }

    void Update() {
        updateCurrentVideoUI();

        if (pCInterface.player.isPlaying) {
            playPause.sprite = play;
        } else {
            playPause.sprite = pause;
        }
    }

    private void updateCurrentVideoUI() {
        pCUI.titleLabel.text = curVideo.videoTitle;
        pCUI.timeCode.text = getTimeCode(pCInterface.player.time) + " / " + getTimeCode(curVideo.videoClip.length);
    }

    public void PlayPause() {
        //rendTex.Release();
        if (pCInterface.player.isPlaying) {
            pCInterface.player.Pause();
        } else {
            pCInterface.player.Play();
        }
    }

    public void RestartVideo() {
        pCInterface.player.Stop();
        rendTex.Release();
    }

    public void ChangeVideo(int selectionIndex) {
        videosList[findUIIndex(curVideo)].selected = false;
        pCInterface.player.Stop();
        rendTex.Release();
        curVideo = videosList[selectionIndex].thisVideo;
        rendTex.width = (int) curVideo.videoClip.width;
        rendTex.height = (int)curVideo.videoClip.height;

        switch (curVideo.layout) {
            case VideoObject.MappingType.TwoD:
                RenderSettings.skybox = videoMats[0];
                break;

            case VideoObject.MappingType.OverUnder:
                RenderSettings.skybox = videoMats[1];
                break;

            case VideoObject.MappingType.SideBySide:
                RenderSettings.skybox = videoMats[2];
                break;
        }

        videosList[selectionIndex].selected = true;
        pCInterface.player.clip = curVideo.videoClip;
    }

    private string getTimeCode(double timeInSeconds) {
        double totalTimeSeconds = timeInSeconds;
        int totalTimeMinutes = Mathf.FloorToInt((float)totalTimeSeconds / 60);
        totalTimeSeconds -= totalTimeMinutes * 60;
        int remainderTotalTimeSeconds = Mathf.FloorToInt((float)totalTimeSeconds);

        if (remainderTotalTimeSeconds < 10) {
            return totalTimeMinutes + ":0" + remainderTotalTimeSeconds;
        } else {
            return totalTimeMinutes + ":" + remainderTotalTimeSeconds;
        }
        
    }

    public int findUIIndex(VideoObject vidToFind) {
        for (int i = 0; i < videosList.Length; i++) {
            if (videosList[i].thisVideo == vidToFind)
                return i;
        }
        return 0;
    }

    public VideoSelectionUI[] populateUIList() {
        List<VideoSelectionUI> videosList = new List<VideoSelectionUI>();
        foreach (VideoObject vid in Videos) {
            GameObject newUIVideo = Instantiate(pCUI.UIPrefab, pCUI.optionsList);
            newUIVideo.GetComponent<VideoSelectionUI>().thisVideo = vid;
            videosList.Add(newUIVideo.GetComponent<VideoSelectionUI>());
        }
        return videosList.ToArray();
    }
}
