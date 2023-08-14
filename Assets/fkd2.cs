using Photon.Pun;
using UnityEngine;

public class fkd2 : MonoBehaviourPun
{
    public GameObject boxPrefab;
    private PhotonView Pv;

    private OVRGrabber grabberScript;

    // Start is called before the first frame update
    void Awake()
    {
        Pv = GetComponent<PhotonView>(); // Get the PhotonView componen

        if (Pv.IsMine)
        {
            Debug.Log("╥ндц");
            GameObject boxInstance = Instantiate(boxPrefab, transform.position, transform.rotation);
            boxInstance.transform.SetParent(transform); // Set as a child of the current object
        }
        else
        {
            Debug.Log("123");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
      
    }


}
