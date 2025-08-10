using System;
using UnityEngine;

public class KeyModel : MonoBehaviour
{
    public int keyMaxCount = 3;
    [NonSerialized] public int[][] KeyTeeth;
    [NonSerialized] public int CollectedKeysCount;

    internal void Reset()
    {
        CollectedKeysCount = 0;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        KeyTeeth = new int[keyMaxCount][];
        for (int i = 0; i < keyMaxCount; i++)
        {
            KeyTeeth[i] = new int[KeyView.TeethCount];
            for (int j = 0; j < KeyView.TeethCount; j++)
            {
                KeyTeeth[i][j] = UnityEngine.Random.Range(1, KeyView.MaxToothLen);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
