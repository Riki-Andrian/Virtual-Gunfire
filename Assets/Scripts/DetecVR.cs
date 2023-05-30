
using UnityEngine;
using UnityEngine.XR.Management;

public class DetecVR : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject desktopCharacter;
    // Start is called before the first frame update
    void Start()
    {
        var xrSettings = XRGeneralSettings.Instance;
        if(xrSettings == null)
        {
            Debug.Log("XRGeneralSetting is null");
            return;
        }

        var xrManager = xrSettings.Manager;
        if(xrManager == null)
        {
            Debug.Log("XRGeneralManager is null");
            return;
        }

        var xrLoader = xrManager.activeLoader;
        if(xrLoader == null)
        {
            Debug.Log("XRGeneralLoader is null");
            xrOrigin.SetActive(false);
            desktopCharacter.SetActive(true);
            return;
        }
         Debug.Log("XRGeneralLoader is not null");
            xrOrigin.SetActive(true);
            desktopCharacter.SetActive(false);
            return;
        
    }

    
}