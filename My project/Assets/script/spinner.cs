using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float xangle = 50f;
    [SerializeField] float yangle = 0f;
    [SerializeField] float zangle = 0f;
    [SerializeField] Vector3 angularVelocity = new Vector3(0f, 90f, 0f);

    // Update is called once per frame
    void Update()
    {
        var delta = Time.deltaTime;
        //transform.Rotate(xangle * delta, yangle * delta, zangle * delta);
        transform.Rotate(angularVelocity * Time.deltaTime);
        
    }
}
