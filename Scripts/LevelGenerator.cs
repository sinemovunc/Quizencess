using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float player_distance_spawnLevel_part = 15f;
    private const int maxLevelParts = 5; // Maksimum bölüm sayýsý

    [SerializeField]
    private Transform levelPart_Start;
    [SerializeField]
    private List<Transform> levelPartList;
    private Queue<Transform> spawnedLevelParts = new Queue<Transform>(); // Bölümleri kuyrukta tutar
    private Vector2 lastEndPosition;
    [SerializeField]
    private Transform Player;

    private void Start()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingLevelParts = 5;
        for (int i = 0; i < startingLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Player != null)
        {
            if (Vector2.Distance(Player.position, lastEndPosition) < player_distance_spawnLevel_part)
            {
                SpawnLevelPart();
            }
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

        // Oluþturulan bölümü kuyruða ekler
        spawnedLevelParts.Enqueue(lastLevelPartTransform);

        // Maksimum bölüm sayýsýný aþtýysa en eski bölümleri kuyruktan çýkarýr ve siler
        if (spawnedLevelParts.Count > maxLevelParts)
        {
            Transform oldestLevelPart = spawnedLevelParts.Dequeue();
            Destroy(oldestLevelPart.gameObject);
        }
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector2 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}