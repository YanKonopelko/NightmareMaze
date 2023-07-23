using System;
using System.Threading.Tasks;
using UnityEngine;

public class FlyingBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var a = new CapsuleCollider();
        if (other.gameObject.tag == "Player" && other.GetType() == a.GetType() )
        {
            other.gameObject.GetComponent<Player>().DealDamage(1);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.BallSound, transform.position);
        }
    }



}
