using UnityEngine;

public class SpikeModel : MonoBehaviour
{
    public int MediumModeSpikeCount = 6;
    public int spikeCount => (int)(GameSessionData.TrapCountFactor * MediumModeSpikeCount);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
