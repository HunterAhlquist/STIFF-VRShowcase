using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour {
    public float speedX;
    public float speedY;
    public float speedZ;
    public bool active;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (active)
            transform.Rotate(new Vector3((1 * speedX), (1 * speedY), (1 * speedZ)));
    }
}
