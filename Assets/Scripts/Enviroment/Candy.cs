using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private int healAmount = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
