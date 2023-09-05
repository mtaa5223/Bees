using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuJoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.X))
        {
            Debug.Log("¾À ¿Å±â±â");
            SceneManager.LoadScene("HomeScene");
        }
        ButtonA();
    }
    void ButtonA()
    {
        
    }
}
