using UnityEngine;

public class mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    //bool isDescending = false;
    void Start()
    {
        
    }
    void Update()
    {
        float xvalue = Input.GetAxis("Horizontal") * Time.deltaTime;
        float yvalue = 0f;
        float zvalue = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xvalue * moveSpeed, yvalue, zvalue * moveSpeed);
    }
}
