using UnityEngine;
using Photon.Pun;

public class WateringCan: MonoBehaviour
{
    public GameObject waterPrefab;     // �� ������Ʈ ������
    public Transform spawnPoint;       // �� ������Ʈ ���� ��ġ
    private float spawnInterval = 0.2f; // ���� ���� (��)
    private float fallSpeed = 2.0f;    // �� ������Ʈ�� �ϰ� �ӵ�

    private void Start()
    {
        // ������ �������� SpawnWater �޼��� ȣ��
        InvokeRepeating("SpawnWater", 0f, spawnInterval);
    }

    // �� ������Ʈ ���� �޼���
    private void SpawnWater()
    {
        // ������Ʈ�� x�� ȸ�� ������ 60������ 90�� ���̿� �ִ� ��쿡�� �� ������Ʈ ����
        if (transform.rotation.eulerAngles.x >= -20 && transform.rotation.eulerAngles.x <= 10)
        {
            Debug.Log("���� ����");
            // �� ������Ʈ�� spawnPoint ��ġ�� �����ϰ�, ȸ���� �������� �ʴ� �⺻ �������� ����
            GameObject waterObject = Instantiate(waterPrefab, spawnPoint.position, Quaternion.identity);

            // Rigidbody ������Ʈ ��������
            Rigidbody rb = waterObject.GetComponent<Rigidbody>();

            // Rigidbody�� �����ϸ�
            if (rb != null)
            {
                // �Ʒ����� �ӵ� ����
                rb.velocity = Vector3.down * fallSpeed;
            }

            // ����� �޽��� ���
            Debug.Log("������Ʈ ����");
        }
    }
}
