using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSelectionUI : MonoBehaviour {
    public VideoObject thisVideo;
    public TextMeshProUGUI titleLabel;
    public Image posterImage;
    public Outline outline;
    
    public bool selected;

    // Start is called before the first frame update
    void Start() {
        titleLabel = transform.parent.parent.Find("VideoSelectionTitle").GetComponent<TextMeshProUGUI>();
        posterImage = GetComponent<Image>();
        outline = GetComponent<Outline>();
        posterImage.sprite = thisVideo.img;
    }

    private void Update() {
        if (selected) {
            outline.enabled = true;
            titleLabel.text = thisVideo.videoTitle;
        } else {
            outline.enabled = false;
        }
    }
}
