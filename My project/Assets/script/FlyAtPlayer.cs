using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float speed = 10f;
    [SerializeField] float arrivedistance = 0.4f;
    Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //targetPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        Vector3 livetarget = Player.position;
        transform.position = Vector3.MoveTowards(transform.position, livetarget, step);
        if (Vector3.Distance(transform.position, livetarget) <= arrivedistance)
        {
            Destroy(gameObject);
        }

    }
}
