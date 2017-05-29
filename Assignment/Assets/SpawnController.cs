using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject Bird;
    public GameObject Baby;
    public GameObject Fruit;

    public List<GameObject> birds;
    public List<GameObject> babies;
    public List<GameObject> fruits;

    public int numBirds = 5;
    public int numBabies = 10;
    public int numFruits = 20;

    public float birdSpawnRadius = 100.0f;
    public float babySpawnRadius = 150.0f;
    public float fruitSpawnRadius = 250.0f;

    public static SpawnController spawner;

    Vector3 position;

    private void Awake()
    {
        spawner = this;
    }

    // Use this for initialization
    void Start () {

        SpawnFruit();
        SpawnBirds();
        SpawnBabies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnBirds()
    {
        for (int i = 0; i < numBirds; i++)
        {
            position = new Vector3(Random.Range(-birdSpawnRadius, birdSpawnRadius), Random.Range(-birdSpawnRadius, birdSpawnRadius), Random.Range(-birdSpawnRadius, birdSpawnRadius));
            birds.Add(Instantiate(Bird, position, Quaternion.identity));
        }//end for
    }

    public void SpawnBabies()
    {
        for (int i = 0; i < numBabies; i++)
        {
            position = new Vector3(Random.Range(-babySpawnRadius, babySpawnRadius), Random.Range(-babySpawnRadius, babySpawnRadius), Random.Range(-babySpawnRadius, babySpawnRadius));
            babies.Add(Instantiate(Baby, position, Quaternion.identity));
        }//end for
    }

    public void SpawnFruit()
    {
        for (int i = 0; i < numFruits; i++)
        {
            position = new Vector3(Random.Range(-fruitSpawnRadius, fruitSpawnRadius), Random.Range(-fruitSpawnRadius, fruitSpawnRadius), Random.Range(-fruitSpawnRadius, fruitSpawnRadius));
            fruits.Add(Instantiate(Fruit, position, Quaternion.identity));
        }//end for
    }

}
