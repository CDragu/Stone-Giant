using UnityEngine;
using System.Collections;

public class TimeTracker : MonoBehaviour {
    public enum Seasons
    {
        Spring,
        Summer,
        Autum,
        Winter
    }
    public Seasons curentSeason;

    public Material grass;

    public Texture2D fadetexture;
    public float fadespeed = 0.5f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadetexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadespeed;
    }
    void OnLevelLoad()
    {
        BeginFade(-1);
    }

    void Start () {
        curentSeason = Seasons.Winter;

    }

    float timer = 0;
	void FixedUpdate() {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        timer += Time.deltaTime;
        if(timer > 3.5f)
        {
            ChangeSeasons();
            MakeWinter();
            timer = 0;
        }
    }
    void ChangeSeasons()
    {
            if (curentSeason == Seasons.Winter)
                curentSeason = Seasons.Spring;
            else
                curentSeason++;
    }
    void MakeWinter()
    {
        if(curentSeason == Seasons.Winter)
        {
            grass.SetFloat(Shader.PropertyToID("_Metallic"), 1f);
        }
        else
        {
            grass.SetFloat(Shader.PropertyToID("_Metallic"), 0f);
        }
    }
}
