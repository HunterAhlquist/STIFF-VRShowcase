using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class DirectorInput : MonoBehaviour {

    public VideoPlayer player;
    public AudioSource aud;

    public KeyCode playPause;
    public KeyCode resetVid;

    public RenderTexture video;

    public VideoClip[] videoClips;
    //public TMP_

    private void Awake() {
        video.Release();
        video.width = (int) player.clip.width;
        video.height = (int) player.clip.height;
    }

    void Update() {
        if (Input.GetKeyDown(playPause)) {
            if (player.isPlaying) {
                player.Pause();
            } else {
                player.Play();
            }
        }

        if (Input.GetKeyDown(resetVid)) {
            player.Stop();
            player.targetTexture.DiscardContents();
            player.targetTexture.Release();
        }
    }
}
