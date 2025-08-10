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

    private MovementDirection lastDirection = MovementDirection.Up;

    public void RandomShift()
    {
        // Get all possible directions
        var possibleDirections = new List<MovementDirection>
        {
            MovementDirection.Up,
            MovementDirection.Down,
            MovementDirection.Left,
            MovementDirection.Right
        };

        possibleDirections.Remove(lastDirection);

        // Remove directions that would go outside the maze
        if (origin.y >= MazeModel.height - 1) possibleDirections.Remove(MovementDirection.Up);
        if (origin.y <= 0) possibleDirections.Remove(MovementDirection.Down);
        if (origin.x >= MazeModel.width - 1) possibleDirections.Remove(MovementDirection.Right);
        if (origin.x <= 0) possibleDirections.Remove(MovementDirection.Left);

        // Safety check
        if (possibleDirections.Count == 0)
            return;

        MovementDirection newDir = possibleDirections[Random.Range(0, possibleDirections.Count)];

        Shift(newDir);

        lastDirection = newDir;
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
        var iterCnt = 10000;
        while (iterCnt-- > 0)
        {
            RandomShift();
        }
        Debug.Log(nameof(OriginShiftAlgorithm) + ":" + nameof(Generate) + " End");
    }
}
