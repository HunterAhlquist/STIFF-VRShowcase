using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour {
    public bool remoteMode;

    public GameObject remotePrefab;
    public GameObject vrRigPrefab;

    void Start() {
        switch (Application.platform) {
            case RuntimePlatform.Android:
                remoteMode = true;
                break;
            case RuntimePlatform.IPhonePlayer:
                remoteMode = true;
                break;
            default:
                remoteMode = false;
                break;
        }

        if (remoteMode) {
            GameObject client = Instantiate(remotePrefab, gameObject.transform);
        } else {
            GameObject server = Instantiate(vrRigPrefab, gameObject.transform);
        }

    }
}
