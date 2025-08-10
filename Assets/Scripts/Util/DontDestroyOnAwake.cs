using UnityEngine;

public class DontDestroyOnAwake : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
