using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour {
    public enum VideoQuality {High, Medium, Low }
    public enum VideoType { ThreeSixty, ThreeDSideBySide, ThreeDOverUnder}

    [Header("Settings")]
    public VideoQuality curQuality;
    public VideoType curType;
    public VideoClip curClip;

    [Header("Content")]
    public VideoClip[] allClips;

    [Header("Components")]
    public VideoPlayer player;
    public RenderTexture[] quality;
    public Material[] type;

    public void UpdateVideo(VideoClip video, VideoType vidType, VideoQuality vidQuality) {
        curClip = video;
        curQuality = vidQuality;
        curType = vidType;

        switch (curType) {
            case VideoType.ThreeSixty:
                RenderSettings.skybox = type[0];
                break;
            case VideoType.ThreeDOverUnder:
                RenderSettings.skybox = type[1];
                break;
            case VideoType.ThreeDSideBySide:
                RenderSettings.skybox = type[2];
                break;
            default:
                RenderSettings.skybox = type[0];
                break;
        }


        
        player.clip = curClip;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
