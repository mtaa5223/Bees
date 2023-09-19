using UnityEngine;
using Photon.Pun;

public class Water: MonoBehaviour
{
    public GameObject waterPrefab;     // 물 오브젝트 프리팹
    public Transform spawnPoint;       // 물 오브젝트 생성 위치
    private float spawnInterval = 0.2f; // 생성 간격 (초)
    private float fallSpeed = 2.0f;    // 물 오브젝트의 하강 속도

    private void Start()
    {
        // 일정한 간격으로 SpawnWater 메서드 호출
        InvokeRepeating("SpawnWater", 0f, spawnInterval);
    }

    // 물 오브젝트 생성 메서드
    private void SpawnWater()
    {
        // 오브젝트의 x축 회전 각도가 60도에서 90도 사이에 있는 경우에만 물 오브젝트 생성
        if (transform.rotation.eulerAngles.x >= 60 && transform.rotation.eulerAngles.x <= 90)
        {
            // 물 오브젝트를 spawnPoint 위치에 생성하고, 회전을 변경하지 않는 기본 방향으로 설정
            GameObject waterObject = PhotonNetwork.Instantiate("waterPrefab", spawnPoint.position, Quaternion.identity);

            // Rigidbody 컴포넌트 가져오기
            Rigidbody rb = waterObject.GetComponent<Rigidbody>();

            // Rigidbody가 존재하면
            if (rb != null)
            {
                // 아래로의 속도 설정
                rb.velocity = Vector3.down * fallSpeed;
            }

            // 디버그 메시지 출력
            Debug.Log("오브젝트 생성");
        }
    }
}
