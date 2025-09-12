using UnityEngine;

public class trigger2 : MonoBehaviour
{
    //[SerializeField] GameObject projectile1;
    [SerializeField] GameObject projectile2;
    /*
    [SerializeField] GameObject projectile3;
    [SerializeField] GameObject projectile4;
    [SerializeField] GameObject projectile5;
    [SerializeField] GameObject projectile6;
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //projectile1.SetActive(true);
            var comp = projectile2.GetComponent<fakeupblockmove>();
            if (comp != null) comp.enabled = true;
            
            /*
            projectile3.SetActive(true);
            projectile4.SetActive(true);
            projectile5.SetActive(true);
            projectile6.SetActive(true);
            */
        }
    }

}
