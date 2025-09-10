using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    MeshRenderer mymesh;
    Rigidbody myrigid;
    [SerializeField] int dropmode = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mymesh = GetComponent<MeshRenderer>();
        mymesh.enabled = false;
        myrigid = GetComponent<Rigidbody>();
        myrigid.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > dropmode)
        {
            mymesh.enabled = true;
            myrigid.useGravity = true;
        }
    }
}
