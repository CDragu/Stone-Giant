using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public GameObject Protagonist;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(Protagonist.transform);
	}
}
