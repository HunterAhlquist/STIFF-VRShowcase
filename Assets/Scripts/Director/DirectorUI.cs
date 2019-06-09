using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectorUI : MonoBehaviour {
    public TextMeshProUGUI titleLabel;
    public TextMeshProUGUI timeCode;
    public PCInput input;
    public GameObject UIPrefab;
    public Transform optionsList;

    public int selectionIndex;

    public VideoDirector director;

    // Update is called once per frame
    void Update() {
        input.UpdateInput();

        if (input.playPause) {
            director.PlayPause();

        } else if (input.moveLeft) {

            if (selectionIndex > 0) {
                selectionIndex--;
                director.ChangeVideo(selectionIndex);
            }
        } else if (input.moveRight) {

            if (selectionIndex < director.Videos.Length - 1) {
                selectionIndex++;
                director.ChangeVideo(selectionIndex);
            }
        } else if (input.restart) {
            director.RestartVideo();

        }

    }

    public void playPause() {

    }

}



[System.Serializable]
public class PCInput {
    public bool moveLeft;
    public bool moveRight;
    public bool playPause;
    public bool restart;

    public void UpdateInput() {
        moveLeft = Input.GetButtonDown("UILeft");
        moveRight = Input.GetButtonDown("UIRight");
        playPause = Input.GetButtonDown("UIPlayPause");
        restart = Input.GetButtonDown("UIReset");
    }
}
