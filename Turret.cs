using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    public int Health;
    public int Bullets;

    public int BulletsPerRound;

    public GameObject BulletPrefab;
    public static Turret Instance;

    public int Score;


    public AudioClip aFireBullet;
    public AudioClip aGotHit;

    void Start()
    {

        Instance = this;
        Health = 10;
        Bullets = 15;
    }

    public void ModifyHealth(int Mod)
    {
        Health = (Health + Mod);

        CameraShake.Instance.shake = CameraShake.Instance.shake + 1;
        if (CameraShake.Instance.shake> 1.5f)
        {
            CameraShake.Instance.shake = CameraShake.Instance.shake = 1.5f;
        }

        if(Health == 0)
        {
            GameManager.Instance.TriggerDeath();
            Application.LoadLevel(0);
        }

        gameObject.GetComponent<AudioSource>().clip = aGotHit;
        gameObject.GetComponent<AudioSource>().Play();


    }


    void Update()
    {
        //Check For Input

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            FireBullet();
        }
    }


    public void FireBullet()
    {
        if (Bullets > 0)
        {
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, new Vector3(gameObject.transform.position.x,
                                                                                  gameObject.transform.position.y - .5f,
                                                                                  0), Quaternion.identity);
            gameObject.GetComponent<AudioSource>().clip = aFireBullet;

            gameObject.GetComponent<AudioSource>().Play();
            Bullets--;
        }
    }

    public void ModBulletCount()
    {
        Bullets = Bullets + BulletsPerRound;
    }

    public void ModScore(int mod)
    {
        Score = Score + mod;
    }
}
