using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            other.gameObject.tag = "Hit";
            Debug.Log("이 물체에 이렇게 여러 번 부딪혔습니다 : " + hits);
        }
    }
}