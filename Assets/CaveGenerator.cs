using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    // Width and Height of the cellmap
    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private bool randomSeed;
    [SerializeField] private int seed;

    [SerializeField][Range(0, 1)] private double initialCellAliveChance;

    private bool[,] cellmap;

    void Start()
    {
        Initialize(width, height, initialCellAliveChance);
    }

    // Initialize cellmap with alive cells
    private void Initialize (int width, int height, double initialCellAliveChance) {
        cellmap = new bool[width, height];
        System.Random rand = randomSeed ? new System.Random(Random.Range(-100000, 100000)) : new System.Random(seed);

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                cellmap[x, y] = rand.NextDouble() < initialCellAliveChance ?  true : false;
            }
        }
    }
}
