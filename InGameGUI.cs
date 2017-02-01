using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour {

    public static InGameGUI Instance;


    void Start()
    {
        Instance = this;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(ModScrn(15, "width"), ModScrn(10, "height"), 100, 20),"Bullets: " + Turret.Instance.Bullets.ToString());
        GUI.Label(new Rect(ModScrn(15, "width"), ModScrn(20, "height"), 100, 20), "Health: " + Turret.Instance.Health.ToString());

        GUI.Label(new Rect(ModScrn(15, "width"), ModScrn(30, "height"), 100, 20), "Score: " + Turret.Instance.Score.ToString());
    }

    public float ModScrn(float x, string dimension)
        {

        if(dimension == "width")
        {
            return (Screen.width / 100) * x;
        }
        else
        {
            return (Screen.height / 100) * x;

        }
    }
}
