using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public float leftBorder;
    public float rightBorder;
    public float spawnRate;
    private float elapsed;
    public float duration;
    public bool isSpawnable;
    // Start is called before the first frame update
    void Start()
    {
        isSpawnable = true;
        StartCoroutine(SpawnAnimal());
        SpawnAnimal();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            spawnRate = Mathf.Lerp(5, 2f, elapsed/duration);
        }
        else
        {
            spawnRate = 2f;
        }
    }
    private IEnumerator SpawnAnimal()
    {
        while (isSpawnable==true)
        {
            float randomX = Random.Range(leftBorder, rightBorder);
            Vector3 randomSpawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            int randomIndex = Random.Range(0, spawnPrefabs.Length);
            Instantiate(spawnPrefabs[randomIndex], randomSpawnPosition, spawnPrefabs[randomIndex].transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
        
    }
   
    
}
  
