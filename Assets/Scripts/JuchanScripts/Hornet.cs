using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hornet : MonoBehaviour
{
    public GameObject target;
    public GameObject BeeKillerPrefab;
    private float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBeeKillerRepeatedly());
    }

    // Update is called once per frame
    void Update()
    {
        // Add any necessary updates here if needed
        FollowTarget();
    }
    void FollowTarget()
    {
        if (target != null)
        {
            // Calculate the new position the Hornet should move to (using Lerp for smooth movement)
            Vector3 newPosition = Vector3.Lerp(transform.position, target.transform.position, Speed * Time.deltaTime);

            // Move the Hornet to the new position
            transform.position = newPosition;
        }
    }

    IEnumerator SpawnBeeKillerRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);

            // Instantiate the BeeKillerPrefab after 10 seconds delay at position (1, 1, 1)
            Instantiate(BeeKillerPrefab, new Vector3(1, 1, 1), Quaternion.identity);


        }
    }

 
}
