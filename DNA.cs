using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DNA : MonoBehaviour {


    public List<Vector2> Genes = new List<Vector2>();
    public List<Vector2> NewGenes = new List<Vector2>();


    public float Fitness;
    public float ClosestToTarget;
    public float BestTimer;
    public float NormalisedFitness;
    public GameObject MyRocket;
    public bool Counting;
    
    // Use this for initialization
	void Start () {

        ClosestToTarget = Mathf.Infinity;
	}
	

    void FixedUpdate()
    {
        if (Counting)
        {
            CalculateBestDistance();
        }
    }

    public void RandomSeed(int Size)
    {
        for (int i = 0; i < Size; i++)
        {
            Vector2 vector = new Vector2(Random.Range(-360, 360), Random.Range(-360, 360));

            Genes.Add(vector);
        }
    }


    public void CalculateBestDistance()
    {
 float dist = Vector2.Distance(GameManager.Instance.ModTargetPos, MyRocket.transform.position);

        if(dist < ClosestToTarget)
        {
            ClosestToTarget = dist;
            BestTimer = MyRocket.GetComponent<Rocket>().Timer;
        }


    }

    public float NormaliseFitness()
    {
          return  1 / ClosestToTarget;
       //   return  (1 / ClosestToTarget) + ((1 / BestTimer) / 2);

    }

    public void RocketSpent()
    {
        NormalisedFitness = NormaliseFitness();

        GeneticAlgo.Instance.ReportRocketSpent();
    }

    public void PrepNewGenes()
    {

        

        //Clear NewGenesList

        NewGenes.Clear();
        //pick two parents from the mating pool

        bool Found = false;

        DNA mum = GeneticAlgo.Instance.MatingPool[Random.Range(0, GeneticAlgo.Instance.MatingPool.Count)];
        DNA dad = GeneticAlgo.Instance.MatingPool[Random.Range(0, GeneticAlgo.Instance.MatingPool.Count)];

        while (Found == false)
        {
             if(mum == dad)
            {
                dad = GeneticAlgo.Instance.MatingPool[Random.Range(0, GeneticAlgo.Instance.MatingPool.Count)];
                
            }
             else
            {
                Found = true;
            }

        }


        //Prteform crossover between parents
        int i = Random.Range(0, GeneticAlgo.Instance.DNASize);


        for (int n = 0; n < Genes.Count; n++)
        {
            if (n < i)
            {
                NewGenes.Add(mum.Genes[n]);
            }
            else
            {
                NewGenes.Add(dad.Genes[n]);

            }
        }

        // add mutation

        for (int x = 0; x < NewGenes.Count; x++)
        {

            if (Random.Range(0f, 100f) < GeneticAlgo.Instance.MutationRate)
            {

                NewGenes[x] = new Vector2(Random.Range(-360, 360), Random.Range(-360, 360));
                Debug.Log("Mutated");
            }



        }
    }

    public void PushNewGenes()
    {
        Genes.Clear();
        foreach (Vector2 v in NewGenes)
        {
            Genes.Add(v);
        }
    }
   
}
