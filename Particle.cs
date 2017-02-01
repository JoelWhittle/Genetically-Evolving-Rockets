using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {


    public float Power;
    public float Lifespan;
    public float Age;
    // Use this for initialization
    void Start () {


        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5,5), Random.Range(-1,5)) * Power);
        gameObject.GetComponent<Rigidbody2D>().AddTorque(Power * 3);

    }

    // Update is called once per frame
    void Update () {

        Age = Age + Time.deltaTime;

        if(Age > Lifespan)
        {
            Destroy(gameObject);
        }
	
	}
}
