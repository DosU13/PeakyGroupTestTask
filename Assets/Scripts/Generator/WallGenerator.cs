using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    private MazeModel mazeModel;
    public GameObject wallPrefab;
    public bool TestMode;

    [NonSerialized] public GameObject[,] verticalWalls;
    [NonSerialized] public GameObject[,] horizontalWalls;

    private void Awake()
    {
        mazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
    }

    void Start()
    {
        verticalWalls = new GameObject[mazeModel.width - 1, mazeModel.height];
        horizontalWalls = new GameObject[mazeModel.width, mazeModel.height - 1];

        // Vertical inner walls
        for (int x = 0; x < mazeModel.width - 1; x++)
        {
            for (int y = 0; y < mazeModel.height; y++)
            {
                Vector3 pos = new Vector3(x + 0.5f, y, 0); 
                GameObject wall = Instantiate(wallPrefab, pos, Quaternion.Euler(0, 0, 90), transform);
                verticalWalls[x, y] = wall;
            }
        }

        // Horizontal inner walls
        for (int x = 0; x < mazeModel.width; x++)
        {
            for (int y = 0; y < mazeModel.height - 1; y++)
            {
                Vector3 pos = new Vector3(x, y + 0.5f, 0); 
                GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity, transform);
                horizontalWalls[x, y] = wall;
            }
        }

        // Outer border
        for (int x = 0; x < mazeModel.width; x++)
        {
            Instantiate(wallPrefab, new Vector3(x, mazeModel.height - 0.5f, 0), Quaternion.identity, transform);
            Instantiate(wallPrefab, new Vector3(x, -0.5f, 0), Quaternion.identity, transform);
        }

        for (int y = 0; y < mazeModel.height; y++)
        {
            Instantiate(wallPrefab, new Vector3(-0.5f, y, 0), Quaternion.Euler(0, 0, 90), transform);
            Instantiate(wallPrefab, new Vector3(mazeModel.width - 0.5f, y, 0), Quaternion.Euler(0, 0, 90), transform);
        }
    }

    void Update()
    {
        for (int x = 0; x < mazeModel.width; x++)
        {
            for (int y = 0; y < mazeModel.height - 1; y++)
            {
                var wall = horizontalWalls[x, y].transform.GetChild(0).gameObject;
                var arrow = horizontalWalls[x, y].transform.GetChild(1).gameObject;
                switch (mazeModel.verticalVectors[x, y])
                {
                    case VerticalVector.Zero:
                        arrow.SetActive(false && TestMode);
                        wall.SetActive(true);
                        break;
                    case VerticalVector.Down:
                        arrow.SetActive(true && TestMode);
                        wall.SetActive(false);
                        arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;  
                    case VerticalVector.Up:
                        arrow.SetActive(true && TestMode);
                        wall.SetActive(false);
                        arrow.transform.rotation = Quaternion.identity;
                        break;
                }
            }
        }

        for (int x = 0; x < mazeModel.width - 1; x++)
        {
            for (int y = 0; y < mazeModel.height; y++)
            {
                var wall = verticalWalls[x, y].transform.GetChild(0).gameObject;
                var arrow = verticalWalls[x, y].transform.GetChild(1).gameObject;
                switch (mazeModel.horizontalVectors[x, y])
                {
                    case HorizontalVector.Zero:
                        arrow.SetActive(false && TestMode);
                        wall.SetActive(true);
                        break;
                    case HorizontalVector.Left:
                        arrow.SetActive(true && TestMode);
                        wall.SetActive(false);
                        arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case HorizontalVector.Right:
                        arrow.SetActive(true && TestMode);
                        wall.SetActive(false);
                        arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
                        break;
                }
            }
        }
    }
}
