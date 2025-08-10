using System;
using UnityEngine;

public class MazeModel : MonoBehaviour
{
    public int width => GameSessionData.MazeSize;
    public int height => GameSessionData.MazeSize;

    public VerticalVector[,] verticalVectors;
    public HorizontalVector[,] horizontalVectors;

    void Awake()
    {
        Debug.Log("MazeModel Start");
        verticalVectors = new VerticalVector[width, height - 1];
        horizontalVectors = new HorizontalVector[width-1, height];
    }
}



