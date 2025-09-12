using UnityEngine;
using System.Collections;
public class fakeupblockmove : MonoBehaviour
{
    [SerializeField] Vector3 targetPos = new Vector3(3.5f, 6f, 3f); // 도착 좌표
    [SerializeField] float speed = 10f;              
     bool hasMoved = false;                 // 이동 속도
    private void OnEnable()
    {
        if (!hasMoved)
        {
            StartCoroutine(MoveBlock());
        }
    }

    IEnumerator MoveBlock()
    {
        hasMoved = true;

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                speed * Time.deltaTime
            );
            yield return null;
        }

        // 최종 위치를 정확히 맞추기
        transform.position = targetPos;
    }
}
