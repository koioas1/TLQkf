using UnityEngine;

public class mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    void Start()
    {
        PrintInstriction();
    }
    void Update()
    {
        movePlyaer();
        /*float Xmouse = Input.GetAxis("Mouse X");
        float Ymouse = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * Xmouse * Time.deltaTime);
        transform.Rotate(Vector3.right * Ymouse * Time.deltaTime);*/
    }

    void PrintInstriction()
    {
        Debug.Log("테스트123123");
    }

    void movePlyaer()
    {
        float xvalue = Input.GetAxis("Horizontal") * Time.deltaTime;
        float yvalue = 0f;
        float zvalue = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xvalue * moveSpeed, yvalue, zvalue * moveSpeed);
    }
}

