using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Teddy curTeddy;
    public int lastRoomNum = 1;

    void Start()
    {
        Instance = this;
    }

    public void Save(Room room) { }
    public void Load() { }
    public void SetBear(Teddy teddy) {
        curTeddy = teddy;  
    }


}
