using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    private float timer = 0;
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 4)
        {
            SceneManager.LoadScene("Level 1");
        }
	}
}
