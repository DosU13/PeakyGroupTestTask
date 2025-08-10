using System.Linq;
using UnityEngine;

public class PuzzleKeyNLockGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject keyPrefab;
    public GameObject lockPrefab;

    [Header("Layout Settings")]
    public float verticalSpacing = 4f;
    public float horizontalSpacing = 3f;
    public Vector3 objectScale = Vector3.one * 1.5f;

    private KeyModel keyModel;

    void Start()
    {
        keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
        if (keyModel == null)
        {
            Debug.LogError("KeyModel not found in resources.");
        }

        if (keyModel == null) return;

        int keyCount = keyModel.keyMaxCount;

        // Precompute lock positions (fixed order)
        Vector3[] lockPositions = new Vector3[keyCount];
        for (int i = 0; i < keyCount; i++)
        {
            float x = horizontalSpacing * (i - (keyCount - 1) / 2f);
            lockPositions[i] = new Vector3(x, verticalSpacing / 2f, 0f);
        }

        // Create locks (with correct teeth patterns)
        for (int i = 0; i < keyCount; i++)
        {
            GameObject lockObj = Instantiate(lockPrefab, lockPositions[i], Quaternion.identity);
            lockObj.transform.localScale = objectScale;

            var lockView = lockObj.GetComponent<LockView>();
            lockView.SetTeeth(keyModel.KeyTeeth[i]);
        }

        // Shuffle indices for keys so they appear in mixed places
        int[] shuffledIndices;
        do
        {
            shuffledIndices = Enumerable.Range(0, keyCount)
                                         .OrderBy(_ => Random.value)
                                         .ToArray();
        }
        while (shuffledIndices.SequenceEqual(Enumerable.Range(0, keyCount)));


        // Create keys (random order)
        for (int i = 0; i < keyCount; i++)
        {
            float x = horizontalSpacing * (i - (keyCount - 1) / 2f);
            Vector3 keyPosition = new Vector3(x, -verticalSpacing / 2f, 0f);

            int keyIndex = shuffledIndices[i];
            GameObject keyObj = Instantiate(keyPrefab, keyPosition, Quaternion.identity);
            keyObj.transform.localScale = objectScale;

            // Add drag logic
            var grabAndDrag = keyObj.AddComponent<GrabAndDrag>();
            grabAndDrag.AnswerPosition = lockPositions[keyIndex]; // Correct match position

            // Set teeth pattern
            var keyView = keyObj.GetComponent<KeyView>();
            keyView.SetTeeth(keyModel.KeyTeeth[keyIndex]);
        }
    }
}
