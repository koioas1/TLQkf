using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class mover : MonoBehaviour
{
    string ideltag;
    float triggertime = 0;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpForce = 8f;
    Rigidbody rb;
    bool isGrounded;
    void Start()
    {
        ideltag = gameObject.tag;
        PrintInstriction();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        movePlyaer();
        jump();
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
        /*
        if (gameObject.tag != ideltag && gameObject.tag == "Hit")
        {
            triggertime = Time.time + 2.5f;
        }
        if (triggertime > 0 && triggertime <= Time.time)
        {
            gameObject.tag = "Player";
            triggertime = 0f;
        }
        ideltag = gameObject.tag;
        */
    }
    Vector3 up = new Vector3(0, 1, 0);
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(up * jumpForce, ForceMode.Impulse); // 위로 힘 가해 점프
            isGrounded = false; // 점프 중
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
 


