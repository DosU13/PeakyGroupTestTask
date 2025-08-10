using System;
using UnityEngine;
using UnityEngine.Events;

public class LockView : MonoBehaviour
{
    void Start()
    {
    }

    public void Collect()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTeeth(int[] teeth)
    {
        var bottomPart = transform.GetChild(0);
        for (int i = 0; i < teeth.Length; i++)
        {
            var factor = teeth[i];
            var gameObject = bottomPart.transform.GetChild(i).gameObject;
            gameObject.transform.localScale = new Vector3(-0.04f * factor, 0.1f, 1);
            gameObject.transform.localPosition = new Vector3(-0.02f * factor - 0.05f, gameObject.transform.localPosition.y, 0);
        }
    }
}
