using Photon.Pun;
using UnityEngine;
using Smooth;
public class fkd : MonoBehaviourPun
{
    public GameObject boxPrefab;
    private PhotonView Pv;
   

   
    // Start is called before the first frame update
    void Awake()
    {
        Pv = GetComponent<PhotonView>(); // Get the PhotonView component

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
    void grab()
    {
        
       
    }
    


}
