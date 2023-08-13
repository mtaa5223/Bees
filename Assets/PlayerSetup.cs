using UnityEngine;
using Photon.Pun;
using System.Linq;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera playerCamera;

    private void Start()
    {
        OVRCameraRig[] cameraRigs = GameObject.FindObjectsOfType<OVRCameraRig>();

        foreach (var cameraRig in cameraRigs)
        {
            if (photonView.IsMine && cameraRig.GetComponentInParent<PhotonView>() == photonView)
            {
                // 로컬 클라이언트의 경우, 해당 플레이어의 OVRCameraRig 활성화
                cameraRig.gameObject.SetActive(true);
            }
            else
            {
                // 다른 플레이어의 경우, OVRCameraRig 비활성화
                cameraRig.gameObject.SetActive(false);
            }
        }
    }
}
