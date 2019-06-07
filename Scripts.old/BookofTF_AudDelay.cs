using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BookofTF_AudDelay : MonoBehaviour {
    public float delayLength;
    float curDelay;

    AudioSource aud;
    public VideoPlayer vid;

    public void ResetDelay() {
        aud.Stop();
        curDelay = delayLength;
        aud.Play();
        aud.Pause();
    }

    private void Start() {
        aud = GetComponent<AudioSource>();
        ResetDelay();
    }
    void FixedUpdate() {
        if (vid.isPlaying) {
            if (curDelay > 0) {
                curDelay -= 0.1f;
            } else {
                if (!aud.isPlaying)
                    aud.UnPause();
            }
        }
        
    }
}
