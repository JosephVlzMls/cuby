using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform target;
    public float distance = 5;
    public float height = 5;
    public float heightDamping = 3;
    public float rotationDamping = 3;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(target) {
            // Calculate the current rotation angles
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;   
            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;
             
            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
         
            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
         
            // Convert the angle into a rotation
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
             
            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            Vector3 pos = target.position;
            pos -= currentRotation * Vector3.forward * distance;
            pos.y = currentHeight;
            transform.position = pos;

            // Always look at the target
            transform.LookAt (target);
         }
    }

}
