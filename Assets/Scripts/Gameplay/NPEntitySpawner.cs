using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPEntitySpawner : MonoBehaviour {

    #region Fields

    // Spawning entities
    [SerializeField]
    GameObject[] prefabNPEntityLeft;
    [SerializeField]
    GameObject[] prefabNPEntityRight;


    // spawn control
    const float MinSpawnDelay = 0.8f;
    const float MaxSpawnDelay = 1.4f;
    [SerializeField]
    int MaxSpawnNumber = 6;
    Timer spawnTimer;
    GameObject tempEntity;

    // spawn location support
    float borderH;
    float borderV;
    float leftSide;
    float rightSide;
    float minSpawnY;
    float maxSpawnY;
    float[] sidesCoordinates = new float[2];
    int spawnSide;
    #endregion

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // save spawn boundaries for efficiency
        leftSide = ScreenUtils.ScreenLeft;
        rightSide = ScreenUtils.ScreenRight;
        minSpawnY = ScreenUtils.ScreenBottom;
        maxSpawnY = ScreenUtils.ScreenTop;
        borderH = (rightSide - leftSide) / 10;
        borderV = (maxSpawnY - minSpawnY) / 10;

        sidesCoordinates[0] = leftSide + borderH;
        sidesCoordinates[1] = rightSide - borderH;

        minSpawnY += borderV;
        maxSpawnY -= borderV;

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for time and number of rocks to spawn a new rock
        int currentNumberOfBirds = GameObject.FindGameObjectsWithTag("Bird").Length;
        if (spawnTimer.Finished && currentNumberOfBirds < MaxSpawnNumber)
        {
            SpawnNPEntity();

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    /// <summary>
    /// Spawns a new NPEntity at a random location
    /// </summary>
    void SpawnNPEntity()
    {
        // generate random location and create new NPEntity
        spawnSide = Random.Range(0, 2);
        tempEntity = spawnSide == 0 ? prefabNPEntityRight[Random.Range(0, prefabNPEntityRight.Length)] :
            prefabNPEntityLeft[Random.Range(0, prefabNPEntityLeft.Length)];
        Vector3 location = new Vector3(sidesCoordinates[spawnSide],
            Random.Range(minSpawnY,maxSpawnY),
            ScreenUtils.ScreenZ);
        GameObject entity = Instantiate(tempEntity) as GameObject;
        entity.transform.position = location;
    }
}
