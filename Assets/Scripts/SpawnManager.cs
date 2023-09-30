using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject toiletPaper;
    [SerializeField] private Vector3[] spawnPositions;
    private int positionIndex;


    void Start()
    {
        positionIndex = Random.RandomRange(0,spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[positionIndex];
        Instantiate(toiletPaper, spawnPosition, toiletPaper.transform.rotation);
    }

}
