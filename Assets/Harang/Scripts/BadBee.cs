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

    [Tooltip("������ �ӵ��Դϴ�")]
    [SerializeField] private float speed;

    private float beeDistance;
    private float honeyBaseDistance;

    [Tooltip("������ ������ �����ϱ� �����ϴ� �Ÿ��Դϴ�")]
    [SerializeField] private float honeyBaseAttackDistance;

    [Tooltip("������ �ܹ��� �����ϱ� �����ϴ� �Ÿ��Դϴ�")]
    [SerializeField] private float beeAttackDistance;
    [Tooltip("������ �ٰ����� �����ϴ� �Ÿ��Դϴ�")]
    [SerializeField] private float beeFollowDistance;

    [Tooltip("�ܹ��� �Ѿ˷� ���� ������ �������� �ð��Դϴ�")]
    [SerializeField] private float slowTime;
    private float slowCurrentTime;
    [Tooltip("�ܹ��� �Ѿ˷� ���� ������ �������� �����Դϴ�")]
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
