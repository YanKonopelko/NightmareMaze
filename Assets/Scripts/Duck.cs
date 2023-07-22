using UnityEngine;

public class Duck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.curTeddy.SetTarget(transform);
        }
    }
}