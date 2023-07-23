using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Teddy curTeddy;
    public int lastRoomNum = 0;
    private Transform spawnPoint;
    [SerializeField] private Transform Player;
    public Action OnReload;

    [SerializeField] private GameObject WinPanel;
    void Awake()
    {
        Instance = this;
    }

    public void Save(Transform spawnPoint) {
        this.spawnPoint = spawnPoint;
        lastRoomNum += 1;
     }
    public void Load() {
        OnReload?.Invoke();
        Player.gameObject.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = spawnPoint.position;
        Player.gameObject.GetComponent<CharacterController>().enabled = true;

        Player.GetComponent<Player>().Heal(15);
    }
    public void SetBear(Teddy teddy) {
        curTeddy = teddy;  
    }

    private void Win()
    {
        WinPanel.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Win();
        }
    }
}
