using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneticAlgo : MonoBehaviour {

    public List<DNA> Population = new List<DNA>();
    public List<GameObject> RocketGameObjects = new List<GameObject>();
    public float MutationRate;
    public GameObject RocketPrefab;
    public int PopulationSize;
    public int DNASize;

    public static GeneticAlgo Instance;

    public int SpentRockets;


    public List<DNA> MatingPool = new List<DNA>();


    // Use this for initialization
    void Start () {

        Instance = this; 
        for(int i = 0; i < PopulationSize; i++)
        {
            GameObject curRocket = (GameObject)GameObject.Instantiate(RocketPrefab, new Vector3(0, 0, -1000), Quaternion.identity);

            RocketGameObjects.Add(curRocket);
       DNA curDNA =   (DNA)gameObject.AddComponent<DNA>();
            Population.Add(curDNA);
            curDNA.RandomSeed(DNASize);

            curRocket.GetComponent<Rocket>().cDNA = curDNA;
            curDNA.MyRocket = curRocket;
        }

        foreach(GameObject curRocketgo in RocketGameObjects)
          {
            foreach (GameObject otherRocketGO in RocketGameObjects)
            {
                if(curRocketgo != otherRocketGO)
                {
                    Physics2D.IgnoreCollision(curRocketgo.GetComponent<Collider2D>(), otherRocketGO.GetComponent<Collider2D>());

                }
            }
        }

        foreach(GameObject RocketGO in RocketGameObjects)
        {
            RocketGO.transform.position = new Vector3(0, 0, 0);
        }


    }

    public void ReportRocketSpent()
    {
        SpentRockets++;

        if(SpentRockets == PopulationSize)
        {
            TriggerNewGeneration();

        }
    }

    public void TriggerNewGeneration()
    {
        SpentRockets = 0;
        Debug.Log("NewGeneration");


        //Clear mating pool

        MatingPool.Clear();
        //populate mating pool
        
        foreach(DNA dna in Population)
        {
            int BreedScore = (int)(dna.NormaliseFitness() * 100);

            int TimeScore = (int)(1 / dna.BestTimer) * 10;

            BreedScore = BreedScore + TimeScore;
            for(int i = 0; i < BreedScore; i++)
            {
                MatingPool.Add(dna);
            }


        }

        //For each DNA .. prep a new sequence 

        foreach(DNA dna in Population)
        {
            dna.PrepNewGenes();
        }
        //For each DNA .. push new sequence

        foreach (DNA dna in Population)
        {
            dna.PushNewGenes();
        }

        //Tell the turret he can have more buttons

        Turret.Instance.ModBulletCount();
        // And give the player some points
        Turret.Instance.ModScore(50);


        //Reset Positions and go!


        foreach (DNA dna in Population)
        {
            Instantiate(dna.MyRocket.GetComponent<Rocket>().ExplosionPrefab, dna.MyRocket.gameObject.transform.position, Quaternion.identity);


            StartCoroutine(dna.MyRocket.GetComponent<Rocket>().FireSequence());
        }
    }


}
