using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;

    [Range(0,1)]
    public float cameraSpeed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");


	}
	
	// Update is called once per frame
	void FixedUpdate() {
        Vector3 target = player.transform.position - new Vector3(0,0,10) ;
        transform.position = Vector3.Lerp(transform.position, target, cameraSpeed);
	}
}
