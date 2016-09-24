using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit_Level_1 : MonoBehaviour {
    public GameObject protagonist;
    public GameObject DM;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == protagonist)
        {
            DM.GetComponent<TimeTracker>().BeginFade(1);
            SceneManager.LoadScene("Level 2");
        }

    }
}
