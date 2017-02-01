using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {

    public float Power;

    public int SequenceLength;
    public List<Vector2> Sequence = new List<Vector2>();


	// Use this for initialization
	void Start () {

        for(int i = 0; i < SequenceLength; i++)
        {
            Vector2 v = new Vector2(Random.Range(-1,1), 1);
            Sequence.Add(v);
        }
        StartCoroutine(FireSequence());
	
	}

    public IEnumerator FireSequence()
    {
        foreach (Vector2 v in Sequence)
        {
            yield return new WaitForSeconds(.2f);
            gameObject.GetComponent<Rigidbody2D> ().AddForce(v * Power);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
