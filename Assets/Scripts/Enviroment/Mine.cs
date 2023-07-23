using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject ExplosionPrefub;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().DealDamage(1); 
            Destroy(gameObject);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.GlassSound, transform.position);

        }
    }
}
