using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private int roomNum = 1;
    [SerializeField] private Teddy Teddy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetBear(Teddy);
            if (GameManager.Instance.lastRoomNum < roomNum)
                GameManager.Instance.Save(this);
        }
        
    }
}
