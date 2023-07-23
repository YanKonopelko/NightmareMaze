using UnityEngine;

public class Puddle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ChangeSpeed(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ChangeSpeed(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(CapsuleCollider))
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundType.PuddleSound, transform.position);
        }
    }

}
