using UnityEngine;
using System.Collections;

public  class GameManager : MonoBehaviour {


    public GameObject Target;
    public Vector3 TargetPos;
    public Vector2 ModTargetPos;

    public static GameManager Instance;
 
	// Use this for initialization
	void Start () {

        Instance = this;
        TargetPos = Target.transform.position;
        ModTargetPos = new Vector2(TargetPos.x, TargetPos.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  public  void TriggerDeath()
    {
        Debug.Log("Dead");
    }


}
