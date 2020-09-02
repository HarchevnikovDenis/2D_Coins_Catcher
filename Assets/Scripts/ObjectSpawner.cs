using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    [SerializeField] private float rate;

    private float lengthOfSideways;
    private float timeFromLastSpawn;

    private void Start()
    {
        lengthOfSideways = PlayerStats.Instance.LengthOfSideways;
        timeFromLastSpawn = rate;
    }

    private void Update()
    {
        if(!PlayerStats.Instance.isGameStart || PlayerStats.Instance.isGameOver)
        {
            return;
        }    

        if(timeFromLastSpawn >= rate)
        {
            SpawnRandomObject();
        }
        else
        {
            timeFromLastSpawn += Time.deltaTime;
        }
    }

    private void SpawnRandomObject()
    {
        float chance = Random.Range(0.0f, 1.0f);

        if(chance > 0.8f)
        {
            Instantiate(objects[0], GetRandomPosition(), Quaternion.identity);
        }
        else
        {
            Instantiate(objects[1], GetRandomPosition(), Quaternion.identity);
        }
        
        timeFromLastSpawn = 0.0f;
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-lengthOfSideways, lengthOfSideways), transform.position.y, transform.position.z);
    }
}
