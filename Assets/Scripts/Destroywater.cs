using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroywater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
