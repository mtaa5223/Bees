using Oculus.Interaction;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class BadBee : MonoBehaviour
{
    private GameObject bee;
    [SerializeField] private Transform honeyBases;

    [SerializeField] private float honeyDamage;

    private GameObject target;
    [SerializeField] private GameObject currentHoneyBase = null;

    [Tooltip("말벌의 속도입니다")]
    [SerializeField] private float speed;

    private float beeDistance;
    private float honeyBaseDistance;

    [Tooltip("말벌이 꿀통을 공격하기 시작하는 거리입니다")]
    [SerializeField] private float honeyBaseAttackDistance;

    [Tooltip("말벌이 꿀벌을 공격하기 시작하는 거리입니다")]
    [SerializeField] private float beeAttackDistance;
    [Tooltip("말벌이 다가오기 시작하는 거리입니다")]
    [SerializeField] private float beeFollowDistance;

    [Tooltip("꿀벌의 총알로 인해 말벌이 느려지는 시간입니다")]
    [SerializeField] private float slowTime;
    private float slowCurrentTime;
    [Tooltip("꿀벌의 총알로 인해 말벌이 느려지는 정도입니다")]
    [SerializeField] private float slowSpeed;

    private void Start()
    {
        bee = GameObject.Find("Bee(Clone)");
        honeyBases = GameObject.Find("HoneyBases").transform;

        slowCurrentTime = slowTime;
    }

    private void Update()
    {
        float badBeeSpeed = speed * Time.deltaTime;

        slowCurrentTime += Time.deltaTime;

        beeDistance = Vector3.Distance(transform.position, bee.transform.position);

        foreach (Transform honeyBase in honeyBases)
        {
            if (!honeyBase.GetComponent<HoneyBase>().NullHoney())
            {
                currentHoneyBase = honeyBase.gameObject;
                transform.LookAt(honeyBase.gameObject.transform.position);
                honeyBaseDistance = Vector3.Distance(transform.position, honeyBase.transform.position);
                break;
            }
            currentHoneyBase = null;
        }

        if (slowCurrentTime < slowTime)
        {
            badBeeSpeed *= slowSpeed;
        }

        if (beeDistance < beeFollowDistance)
        {
            transform.LookAt(bee.transform);
            if (beeDistance > beeAttackDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, bee.transform.position, speed * Time.deltaTime);
            }
        }
        else if (currentHoneyBase != null)
        {
            if (honeyBaseDistance > honeyBaseAttackDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentHoneyBase.transform.position, speed * Time.deltaTime);
            }
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        
        if (currentHoneyBase != null && honeyBaseDistance <= honeyBaseAttackDistance)
        {
            //Debug.Log("Attack!");
            currentHoneyBase.GetComponent<HoneyBase>().DeleteHoney(honeyDamage * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            slowCurrentTime = 0;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Bowl") && other.GetComponent<Bowl>() != null)
        {
            if (other.GetComponent<Bowl>().isBowlAttack)
            {
                Debug.Log("Destroyed.");
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bowl") && collision.gameObject.GetComponent<Bowl>() != null)
        {
            Debug.Log("Collision" + ", isBowlAttack : " + collision.gameObject.GetComponent<Bowl>().isBowlAttack);
            if (collision.gameObject.GetComponent<Bowl>().isBowlAttack)
            {
                Debug.Log("Destroyed.");
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
