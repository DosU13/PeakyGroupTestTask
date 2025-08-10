using System;
using UnityEngine;

public class SpikeView : MonoBehaviour
{
    private float timeOffset;
    private GameObject rbComponent;

    void Start()
    {
        rbComponent = transform.GetChild(0).gameObject;
        timeOffset = UnityEngine.Random.value;
    }

    void Update()
    {
        // alternating on/off every second
        int currentSecond = Mathf.FloorToInt(Time.time+timeOffset);
        bool active = (currentSecond % 2) == 0;

        rbComponent.SetActive(active);
    }
}
