using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtSpawner : MonoBehaviour
{
    public Enemy[] SpawnerPrefabs;

    public float timer;
    public float startspawntime;
    [Range(0.0f,1f)]
    public float spawnWait;
    public float wavewait;
    public Transform[] SpawnPoints;
    public float  wavesize;
   public  bool SpawnerOn;
    public int WaveCount;
    public GameManager manager;

    private void Start()
    {
        WaveCount = 0;
        SpawnerOn = true;
        StartCoroutine(SpawnWaves());
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Time.time> startspawntime)
        { 


        }
    }

IEnumerator    SpawnWaves()
    {
        while (SpawnerOn)
        {
            yield return new WaitForSeconds(startspawntime);

            for (int j = 0; j < wavesize; j++)
            {
                int i = Random.Range(0, SpawnPoints.Length);
                int k = Random.Range(0, SpawnerPrefabs.Length);

                Instantiate(SpawnerPrefabs[k], SpawnPoints[i].position, Quaternion.identity);

                
                yield return new WaitForSeconds(Random.Range(0,spawnWait)  );






            }
            WaveCount++;
            manager.setWave(WaveCount);
            yield return new WaitForSeconds(wavewait);
        }
        


    }
}
