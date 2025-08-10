using System.Linq;
using UnityEngine;

/// <summary>
/// Whenever Puzzle Scene loaded from editor, there wouldn't be KeyModel, since MainScene didn't run, so this script create it, if it doesn't exist
/// ������ ���, ����� Puzzle Scene ����������� �� ���������, �� ����� KeyModel � ����, ��������� MainScene ��� �� ��� �������, ������� ���� ������ ������� ��, ������ �� �� �������������.
/// </summary>
public class TestKeyModel : MonoBehaviour
{
    private void Awake()
    {
        var keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
        if (keyModel == null)
        {
            gameObject.AddComponent<KeyModel>();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
