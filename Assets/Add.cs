using UnityEngine;
using Photon.Pun;

public class Add : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        if (photonView.IsMine)
        {
            RemoveOVRManagerScript();
        }
    }

    void RemoveOVRManagerScript()
    {
        OVRManager ovrManager = GetComponentInChildren<OVRManager>();
        if (ovrManager != null)
        {
            Destroy(ovrManager);
        }
    }
}
