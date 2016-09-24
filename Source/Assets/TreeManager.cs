using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {

    public GameObject GM;

    public TimeTracker.Seasons currnetSeason;
    

    public ParticleSystem Spring;
    public ParticleSystem Summer;
    public ParticleSystem Autum;

    void Start () {
       
    }
	
	
	void Update () {
        currnetSeason = GM.GetComponent<TimeTracker>().curentSeason;

        switch (currnetSeason)
        {
            case TimeTracker.Seasons.Spring:
                if(Spring.isPlaying == false)
                    Spring.Play();
                Summer.Stop();
                Autum.Stop();
                break;
            case TimeTracker.Seasons.Summer:
                Spring.Stop();
                if (Summer.isPlaying == false)
                    Summer.Play();
                Autum.Stop();
                break;
            case TimeTracker.Seasons.Autum:
                Spring.Stop();
                Summer.Stop();
                if(Autum.isPlaying ==false)
                    Autum.Play();
                break;
            default:
                Spring.Stop();
                Summer.Stop();
                Autum.Stop();
                break;

        }
	}
}
