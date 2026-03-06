using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float sideSpawnMinZ = 10;
    private float sideSpawnMaxZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnSide = Random.Range(0, 3); // 0 topo, 1 esquerda, 2 direita

        Vector3 spawnPos;
        Quaternion spawnRot;

        if (spawnSide == 0) // topo
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            spawnRot = animalPrefabs[animalIndex].transform.rotation;
        }
        else if (spawnSide == 1) // esquerda
        {
            spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
            spawnRot = Quaternion.Euler(0, 90, 0); // vira para o centro
        }
        else // direita
        {
            spawnPos = new Vector3(spawnRangeX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
            spawnRot = Quaternion.Euler(0, -90, 0); // vira para o centro
        }

        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRot);
    }
}