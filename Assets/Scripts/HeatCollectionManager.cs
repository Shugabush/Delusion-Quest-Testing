using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatCollectionManager : MonoBehaviour
{
    [SerializeField] CollectableSprite spritePrefab;
    List<CollectableSprite> spawnedSprites = new List<CollectableSprite>();
    const int maxSpriteCount = 10;
    [SerializeField] Timer spawnTimer = new Timer(5f);

    [SerializeField] SpawnPoint[] spawnPoints = new SpawnPoint[0];

    static HeatCollectionManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (spawnedSprites.Count < maxSpriteCount)
        {
            spawnTimer.Update(Time.deltaTime);
            if (spawnTimer.OutOfTime)
            {
                // Spawn a sprite at a random spawn point
                SpawnPoint targetSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

                CollectableSprite newSprite = Instantiate(spritePrefab, transform);
                targetSpawnPoint.ManageSprite(newSprite);
                spawnedSprites.Add(newSprite);

                spawnTimer.Reset();
            }
        }
    }

    public static void RemoveSprite(CollectableSprite sprite)
    {
        instance.spawnedSprites.Remove(sprite);
    }

    public static void End()
    {
        instance.gameObject.SetActive(false);
    }
}
