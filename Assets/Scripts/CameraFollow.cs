using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    Camera cam1;

	// Use this for initialization
	void Start () {

        cam1 = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {

        cam1.orthographicSize = (Screen.height / 100f) / 1.8f; 

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f) + new Vector3(0, 0, -10);
        }
	
	}
}
