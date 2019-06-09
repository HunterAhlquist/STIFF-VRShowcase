using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VRLobby : MonoBehaviour {
    public VideoPlayer player;

    public GameObject videoUI;
    public GameObject lobby;

    // Update is called once per frame
    void Update() {
        if (!player.isPlaying) {
            lobby.SetActive(true);
            videoUI.SetActive(true);
        } else {
            lobby.SetActive(false);
            videoUI.SetActive(false);
        }
    }
}
