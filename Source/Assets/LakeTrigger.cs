using UnityEngine;
using System.Collections;

public class LakeTrigger : MonoBehaviour {

    public GameObject protagonist;
    public GameObject river;
    public GameObject Baraj;

    public bool incollider = false , riverloaded = false , baraje = true;

    public float maxheight, maxrise = 2f, riseammount;
	// Use this for initialization
	void Start () {
        maxheight = river.transform.position.y + maxrise;
	}
	
	// Update is called once per frame
	void Update () {
        CreateBaraje();
        if(baraje == false)
        {
            DestroyBaraj();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == protagonist)
        {
            incollider = true;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == protagonist)
        {
            incollider = false;
        }
    }
    void CreateBaraje()
    {
        if (incollider == true && protagonist.GetComponent<StoneGiantController>().crouch == true)
        {
            if (river.transform.position.y <= maxheight)
                river.transform.Translate(0, riseammount, 0);
        }
        else
        {
            if (river.transform.position.y > maxheight - maxrise)
            {
                river.transform.Translate(new Vector3(0, -riseammount, 0));
            }
            if (riverloaded == true)
                baraje = false;
        }
        if(river.transform.position.y > maxheight - 0.1f)
        {
            riverloaded = true;
        }
    }
    void DestroyBaraj()
    {
        if(Baraj != null)
        {
            Baraj.transform.Translate(new Vector3(0, -0.1f, 0));
            if (Baraj.transform.position.y < 0)
                Destroy(Baraj);
        }
    }
}
