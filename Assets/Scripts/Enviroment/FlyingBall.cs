using System;
using System.Threading.Tasks;
using UnityEngine;

public class FlyingBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(CapsuleCollider))
        {
            other.gameObject.GetComponent<Player>().DealDamage(1);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.BallSound, transform.position);
        }
    }



}
