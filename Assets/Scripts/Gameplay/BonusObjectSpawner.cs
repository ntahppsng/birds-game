using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObjectSpawner : MonoBehaviour {

    #region Fields

    // needed for spawning
    [SerializeField]
    GameObject[] prefabBonusObject;

    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    const int MaxSpawnNumber = 1;
    Timer spawnTimer;

    // spawn location support
    const int SpawnBorderSize = 100;
    float minSpawnX;
    float maxSpawnX;
    float minSpawnY;
    float maxSpawnY;
    float borderH;
    float borderV;

    #endregion

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // save spawn boundaries for efficiency
        minSpawnX = ScreenUtils.ScreenLeft;
        maxSpawnX = ScreenUtils.ScreenRight;
        minSpawnY = ScreenUtils.ScreenBottom;
        maxSpawnY = ScreenUtils.ScreenTop;
        borderH = (maxSpawnX - minSpawnX) / 6;
        borderV = (maxSpawnY - minSpawnY) / 6;
        minSpawnX += borderH;
        maxSpawnX -= borderH;
        minSpawnY += borderV;
        maxSpawnY -= borderV;


        EventManager.AddBonusBarCompletedListener(SpawnBonusObject);
    }


    /// <summary>
    /// Spawns a new NPEntity at a random location
    /// </summary>
    public void SpawnBonusObject()
    {
        // generate random location and create new NPEntity
        Vector3 location = new Vector3(Random.Range(minSpawnX,maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            ScreenUtils.ScreenZ);
        GameObject entity = Instantiate(prefabBonusObject[Random.Range(0, prefabBonusObject.Length)]) as GameObject;
        entity.transform.position = location;
    }
}
