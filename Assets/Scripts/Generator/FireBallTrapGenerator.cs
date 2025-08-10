using System.Linq;
using System.Security.Principal;
using UnityEngine;

public class FireBallTrapGenerator : MonoBehaviour
{
    public GameObject FireballPrefab;
    private WallGenerator wallGenerator; 
    public float MediumModeSpawnInterval = 1f;
    
    private float spawnInterval => MediumModeSpawnInterval / GameSessionData.TrapCountFactor;
    private float spawnTimer;

    private void Awake()
    {
        wallGenerator = Resources.FindObjectsOfTypeAll<WallGenerator>().FirstOrDefault();
    }

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnRandomFireball();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnRandomFireball()
    {
        int safety = 100; // prevent infinite loop
        while (safety-- > 0)
        {
            bool vertical = Random.value > 0.5f;

            if (vertical && wallGenerator.verticalWalls != null)
            {
                int x = Random.Range(1, wallGenerator.verticalWalls.GetLength(0) - 1); // avoid borders
                int y = Random.Range(0, wallGenerator.verticalWalls.GetLength(1));
                GameObject wall = wallGenerator.verticalWalls[x, y];

                if (wall != null && wall.transform.GetChild(0).gameObject.activeSelf)
                {
                    Vector3 spawnPos = wall.transform.position;
                    Quaternion rot = Random.value > 0.5f
                        ? Quaternion.Euler(0, 0, 90)     // right
                        : Quaternion.Euler(0, 0, 270);   // left
                    Instantiate(FireballPrefab, spawnPos, rot, transform);
                    return;
                }
            }
            else if (!vertical && wallGenerator.horizontalWalls != null)
            {
                int x = Random.Range(0, wallGenerator.horizontalWalls.GetLength(0));
                int y = Random.Range(1, wallGenerator.horizontalWalls.GetLength(1) - 1); // avoid borders
                GameObject wall = wallGenerator.horizontalWalls[x, y];

                if (wall != null && wall.transform.GetChild(0).gameObject.activeSelf)
                {
                    Vector3 spawnPos = wall.transform.position;
                    Quaternion rot = Random.value > 0.5f
                        ? Quaternion.Euler(0, 0, 0)      // up
                        : Quaternion.Euler(0, 0, 180);   // down
                    Instantiate(FireballPrefab, spawnPos, rot, transform);
                    return;
                }
            }
        }

        Debug.LogWarning("No active walls found to spawn fireball.");
    }

}
