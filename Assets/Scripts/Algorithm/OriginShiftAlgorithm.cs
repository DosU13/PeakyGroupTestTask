using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OriginShiftAlgorithm : MonoBehaviour
{
    private MazeModel MazeModel;

    private void Awake()
    {
        MazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
    }

    private Vector2Int origin;
    public void Shift(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.Up:
                origin.y++;
                MazeModel.verticalVectors[origin.x, origin.y - 1] = VerticalVector.Up;
                break;
            case MovementDirection.Down:
                origin.y--;
                MazeModel.verticalVectors[origin.x, origin.y] = VerticalVector.Down;
                break;
            case MovementDirection.Left:
                origin.x--;
                MazeModel.horizontalVectors[origin.x, origin.y] = HorizontalVector.Left;
                break;
            case MovementDirection.Right:
                origin.x++;
                MazeModel.horizontalVectors[origin.x - 1, origin.y] = HorizontalVector.Right;
                break;
        }
        if (origin.y < MazeModel.height - 1 &&
            MazeModel.verticalVectors[origin.x, origin.y] == VerticalVector.Up)
            MazeModel.verticalVectors[origin.x, origin.y] = VerticalVector.Zero;
        if (origin.y > 0 &&
            MazeModel.verticalVectors[origin.x, origin.y - 1] == VerticalVector.Down)
            MazeModel.verticalVectors[origin.x, origin.y - 1] = VerticalVector.Zero;
        if (origin.x > 0 && 
            MazeModel.horizontalVectors[origin.x - 1, origin.y] == HorizontalVector.Left)
            MazeModel.horizontalVectors[origin.x - 1, origin.y] = HorizontalVector.Zero;
        if (origin.x < MazeModel.width - 1 && 
            MazeModel.horizontalVectors[origin.x, origin.y] == HorizontalVector.Right)
            MazeModel.horizontalVectors[origin.x, origin.y] = HorizontalVector.Zero;
    }


    private List<MovementDirection> ShiftPath = new();
    private void FixedUpdate()
    {
        if (ShiftPath.Count <= 0) return;
        for (int i = 0; i < ShiftPath.Count / 4; i++)
        {
            Shift(ShiftPath[i]);
        }
        ShiftPath.RemoveRange(0, ShiftPath.Count/4);
    }


    public void AsyncRandomShift()
    {
        ShiftPath = GeneratePathForShift();
    }

    public void RandomShift()
    {
        var path = GeneratePathForShift();
        foreach (var d in path)
        {
            Shift(d);
        }
    }
    public List<MovementDirection> GeneratePathForShift()
    {
        var res = new List<MovementDirection>();
        bool[,] visited = new bool[MazeModel.width, MazeModel.height];
        List<Vector2Int> notVisited;
        var point = new Vector2Int(origin.x, origin.y);
        do
        {
            notVisited = new();
            for (int i = 0; i < MazeModel.width; i++)
            {
                for (int j = 0; j < MazeModel.height; j++)
                {
                    if (!visited[i, j]) notVisited.Add(new Vector2Int(i, j));
                }
            }

            if (notVisited.Count == 0) continue;
            var shiftPath = GeneratePathForShift(point, notVisited[Random.Range(0, notVisited.Count)]);
            foreach (var d in shiftPath)
            {
                switch (d)
                {
                    case MovementDirection.Up:
                        point.y++;
                        break;
                    case MovementDirection.Down:
                        point.y--;
                        break;
                    case MovementDirection.Left:
                        point.x--;
                        break;
                    case MovementDirection.Right:
                        point.x++;
                        break;
                }
                visited[point.x, point.y] = true;
            }
            res.AddRange(shiftPath);
        }while (notVisited.Count > 0);
        return res;
    }

    private List<MovementDirection> GeneratePathForShift(Vector2Int from, Vector2Int to)
    {
        var res = new List<MovementDirection>();
        if (to.x > from.x)
        {
            res.AddRange(Enumerable.Repeat(MovementDirection.Right, to.x - from.x));
        }
        else
        {
            res.AddRange(Enumerable.Repeat(MovementDirection.Left, from.x - to.x));
        }

        if (to.y > from.y)
        {
            res.AddRange(Enumerable.Repeat(MovementDirection.Up, to.y - from.y));
        }
        else
        {
            res.AddRange(Enumerable.Repeat(MovementDirection.Down, from.y - to.y));
        }
        res = res.OrderBy(_ => Random.value).ToList();
        return res;
    }


    public void Generate()
    {
        for (int x = 0; x < MazeModel.width; x++)
        {
            for (int y = 0; y < MazeModel.height - 1; y++)
            {
                MazeModel.verticalVectors[x, y] = x == 0 ? VerticalVector.Down : VerticalVector.Zero;
            }
        }
        for (int x = 0; x < MazeModel.width - 1; x++)
        {
            for (int y = 0; y < MazeModel.height; y++)
            {
                MazeModel.horizontalVectors[x, y] = HorizontalVector.Left;
            }
        }
        origin = new Vector2Int(0, 0);
        RandomShift();
        Debug.Log(nameof(OriginShiftAlgorithm) + ":" + nameof(Generate) + " End");
    }
}
