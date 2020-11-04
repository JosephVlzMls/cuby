using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {
    
    float lastMovementTime = 0;

    void Start() {
        
    }

    void Update() {
        if(Time.time - lastMovementTime > 0.01) {
            if(transform.position.z < -50.0) {
                transform.position = new Vector3(0, 0.5f, 230.0f);
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            transform.Translate(0, 0, -0.45f);
            lastMovementTime = Time.time;
        }
    }

}
