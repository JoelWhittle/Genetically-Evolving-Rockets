using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public DNA cDNA;
    public float Power;
    public bool Spent;

    public float Timer;


    public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () {

        
        StartCoroutine(FireSequence());
	}
	


    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0 & gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
         //   transform.rotation = Quaternion.LookRotation(gameObject.GetComponent<Rigidbody2D>().velocity, Vector2.up);
        }
    }
    public IEnumerator FireSequence()
    {

        //Reset timer
        Timer = 0;
        //tell dna to start counting
        cDNA.Counting = true;
     //   Debug.Log("FireSequence");
     cDNA.ClosestToTarget = Mathf.Infinity;

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Quaternion rot = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<Transform>().rotation = rot;

        gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;



        Spent = false;
        yield return new WaitForSeconds(1f);

    
        foreach (Vector2 vector in cDNA.Genes)
        {
            yield return new WaitForSeconds(.1f);

            gameObject.GetComponent<Rigidbody2D>().AddForce(vector * Power);
            Timer++;
        }

        Spent = true;

        cDNA.RocketSpent();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Target")
        {
            coll.gameObject.GetComponent <Turret>().ModifyHealth(-1);

            //hide this rocket
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);


            //tell dna to stop countin
            cDNA.Counting = false;
          }
    }

    public void TriggerDestroyed()
    {
        //hide this rocket
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;


        //tell dna to stop countin
        cDNA.Counting = false;

        //spawn fx

        Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
        //sound

        gameObject.GetComponent<AudioSource>().Play();
    }

}
