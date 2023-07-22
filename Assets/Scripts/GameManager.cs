using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Teddy curTeddy;


    void Start()
    {
        Instance = this;
    }

    public void Save() { }
    public void Load() { }
    public void SetBear(Teddy teddy) {
        curTeddy = teddy;  
    }


}
