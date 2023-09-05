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
                // ���� Ŭ���̾�Ʈ�� ���, �ش� �÷��̾��� OVRCameraRig Ȱ��ȭ
                cameraRig.gameObject.SetActive(true);
            }
            else
            {
                // �ٸ� �÷��̾��� ���, OVRCameraRig ��Ȱ��ȭ
                cameraRig.gameObject.SetActive(false);
            }
        }
    }
}
