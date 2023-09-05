using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFind : MonoBehaviour
{
    [SerializeField] private string modelName;
    [SerializeField] private GameObject modelObject;

    private void Start()
    {
        modelObject = transform.parent.parent.parent.parent.Find(modelName).gameObject;
    }

    private void Update()
    {
        modelObject.transform.position = transform.position;
        modelObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - 90, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);

        if (modelName == "Body")
        {
            modelObject.transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
        }
    }
}
