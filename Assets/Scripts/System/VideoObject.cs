using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "newVideo", menuName = "VR Video/Video", order = 1)]
public class VideoObject : ScriptableObject
{
    public VideoClip videoClip;
    [Space]
    [Header("Properties")]
    public string videoTitle;
    public bool monoMode;
}
