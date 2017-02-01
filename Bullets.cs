using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

    // Use this for initialization

    public float Power;
    public float Lifespan;
    public float Age;

        void Start()
    {

            Vector3 pmousePos = GameObject.Find("Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = pmousePos - transform.position;
        Vector2 modDir = new Vector2(dir.x,dir.y);

        Vector2 normalizedDir = modDir.normalized;
        gameObject.GetComponent<Rigidbody2D>().AddForce(normalizedDir * Power);
        }
    
	// Update is called once per frame
	void FixedUpdate () {

        Age = Age + Time.deltaTime;

        if(Age > Lifespan)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Rocket")
        {

            //tell rocket to remove its self from the gene pool
            //and hide it, then play fx

            coll.gameObject.GetComponent<Rocket>().TriggerDestroyed();

            //then destroy this bullet
            Destroy(gameObject);

            //then give the player some points


            Turret.Instance.ModScore(5);
        }
    }

}
