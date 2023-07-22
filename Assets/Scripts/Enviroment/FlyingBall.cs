using System.Threading.Tasks;
using UnityEngine;

public class FlyingBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().DealDamage(1);
        }
    }



}
