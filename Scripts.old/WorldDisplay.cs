using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WorldDisplay : MonoBehaviour {
    public VideoPlayer vid;
    public GameObject target;

    void Update() {
        //Debug.Log(vid.isPlaying);
        if (vid.isPlaying) {
            target.SetActive(false);
        } else {
            target.SetActive(true);
        }
    }
}
