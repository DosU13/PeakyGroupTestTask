using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PortalGenerator : MonoBehaviour
{
    public GameObject PortalPrefab;
    private MazeModel mazeModel;

    void Awake()
    {
        mazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
    }

    public void CreatePortal()
    {
        Vector2Int cell = new Vector2Int(
            Random.Range(0, mazeModel.width),
            Random.Range(0, mazeModel.height)
        );

        var pos = new Vector3(cell.x, cell.y, 0f);
        GameObject spike = Instantiate(PortalPrefab, pos, Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
