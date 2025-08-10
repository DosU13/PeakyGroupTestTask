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
    }

    public void OnKeyCollected()
    {
        keyModel.CollectedKeysCount++;
        if (keyModel.CollectedKeysCount >= keyModel.keyMaxCount)
        {
            portalController.CreatePortal();
        }
    }
}
