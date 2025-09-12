using UnityEngine;

public class BlockPingPong : MonoBehaviour
{
    [SerializeField] Vector3 pointA = new Vector3(5f, 1.5f, 6f); // 시작 지점 A
    [SerializeField] Vector3 pointB = new Vector3( 5f, 6f, 06); // 도착 지점 B
    [SerializeField] float speed = 5f;                         // 이동 속도

    private Vector3 target;  // 현재 목표 지점

    void Start()
    {
        // 시작할 때 이미 A에 있다고 가정, 목표는 B로 설정
        transform.position = pointA;
        target = pointB;
    }

    void Update()
    {
        // 목표를 향해 이동
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // 목표에 도달하면 반대로 전환
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
