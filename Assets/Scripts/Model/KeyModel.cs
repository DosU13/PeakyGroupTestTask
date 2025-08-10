using System;
using UnityEngine;

public class KeyModel : MonoBehaviour
{
    public int keyCount = 3;
    [NonSerialized] public int[][] KeyTeeth;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        KeyTeeth = new int[keyCount][];
        for (int i = 0; i < keyCount; i++)
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
