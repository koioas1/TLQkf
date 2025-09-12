using UnityEngine;

public class trigger3 : MonoBehaviour
{
    [SerializeField] GameObject projectile1;
    [SerializeField] GameObject projectile2;
    /*
    [SerializeField] GameObject projectile4;
    [SerializeField] GameObject projectile5;
    [SerializeField] GameObject projectile6;
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            projectile1.SetActive(false);
            projectile2.SetActive(true);
            
            /*
            projectile3.SetActive(true);
            projectile4.SetActive(true);
            projectile5.SetActive(true);
            projectile6.SetActive(true);
            */
        }
    }

}