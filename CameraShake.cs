using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public static CameraShake Instance;



   public Camera camera; // set this via inspector
public float shake = 0;
public float shakeAmount  = 0.7f;
public float decreaseFactor   = 1.0f;



    // Use this for initialization
    void Start () {

        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {

        if (shake > 0)
        {
            camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;

        }
        else
        {
            shake = 0.0f;
        }

    }


 

}
