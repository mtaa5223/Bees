using UnityEngine;


public class ShotBullet : MonoBehaviour
{


    public void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HoneyBase"))
        {
            other.gameObject.transform.GetComponent<HoneyBase>().AddHoney(10);
            Debug.Log(other.name);
            Destroy(gameObject);
        }

    }


}
