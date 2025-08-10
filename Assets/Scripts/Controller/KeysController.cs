using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class KeysController : MonoBehaviour
{
    private KeyModel keyModel;
    private PortalGenerator portalController;

    private void Awake()
    {
        keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
        portalController = Resources.FindObjectsOfTypeAll<PortalGenerator>().FirstOrDefault();
    }

    void Start()
    {
        keyCount = keyModel.keyCount;
    }

    private int keyCount;
    public void OnKeyCollected()
    {
        keyCount--;
        if (keyCount == 0)
        {
            portalController.CreatePortal();
        }
    }
}
