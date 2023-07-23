using UnityEngine;

public class Duck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var a = new CapsuleCollider();
        if (other.gameObject.tag == "Player" && other.GetType() == a.GetType())
        {
            GameManager.Instance.curTeddy.SetTarget(transform);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.DuckSound, transform.position);
        }
    }
}
