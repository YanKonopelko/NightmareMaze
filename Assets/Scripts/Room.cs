using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private int roomNum = 0;
    [SerializeField] private Teddy Teddy;
    [SerializeField] private Transform SpawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Room");
            GameManager.Instance.SetBear(Teddy);
            Debug.Log(GameManager.Instance.lastRoomNum < roomNum);
            if (GameManager.Instance.lastRoomNum < roomNum)
                GameManager.Instance.Save(SpawnPoint);
        }
        
    }
}
