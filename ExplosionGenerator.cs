using UnityEngine;
using System.Collections;


public class ExplosionGenerator : MonoBehaviour {



    public GameObject RedParticle;
    public GameObject OrangeParticle;
    public GameObject YellowParticle;

    // Use this for initialization
    void Start () {

        int redParts = Random.Range(20, 30);
        int orangeParts = Random.Range(20, 30);
        int yellowParts = Random.Range(20, 35);

        for (int i = 0; i < redParts; i++)
        {
           
                Instantiate(RedParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
        for (int i = 0; i < orangeParts; i++)
        {

            Instantiate(OrangeParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
        for (int i = 0; i < yellowParts; i++)
        {

            Instantiate(YellowParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
	
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
