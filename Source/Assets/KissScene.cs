using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KissScene : MonoBehaviour {

    public GameObject protagonist;
    public Animator anim;
    public GameObject sphere;
    public bool kiss = false;
    public bool end = false;
    public GameObject DM;
    public AudioSource kisssound;

    void Start () {
        //AudioSource audio = GetComponent<AudioSource>();
    }

    private float timer;
	void Update () {
	    if(end == true)
        {
            timer+=Time.deltaTime;
        }
        if(timer > 2 && timer < 3)
        {
            if (kisssound.isPlaying != true)
                kisssound.Play();
        }
        if (timer > 2)
        {
            sphere.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (timer > 4)
        {
            DM.GetComponent<TimeTracker>().BeginFade(1);
        }
        if(timer > 6)
        {
            SceneManager.LoadScene("End");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == protagonist)
        {
            kiss = true;
            protagonist.GetComponent<StoneGiantController>().anim.SetBool("Kiss", kiss);
            if((this.transform.position - protagonist.transform.position).sqrMagnitude > 1)
            {
                this.transform.LookAt(protagonist.transform);
                end = true;
                //kisssound.Play();
                this.transform.Translate(0, 0, 2);
            }
        }
    }
}
