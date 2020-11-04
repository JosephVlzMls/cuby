using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    bool jump = true;
    public float power = 100.0f;
    public float speed = 3.0f;
    
    void Start() {
        
    }

    void Update() {
        var y = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        x += transform.position.x;
        if(x >= 9.5) x = 9.49f;
        if(x <= -9.5) x = -9.49f;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        if(y > 0 && jump) {
            GetComponent<Rigidbody>().AddForce (0, power, 0);
            jump = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
        jump = true;
        if(collision.collider.CompareTag("Plane")) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    void OnCollisionStay(Collision collision) {
        if(transform.position.z < -1.5) {
            transform.position = new Vector3(0, 10, 0);
        }
    }

}
