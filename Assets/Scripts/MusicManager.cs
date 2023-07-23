using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public float volume = 0.5f;

    [SerializeField] private float volumeK = 0.7f;
    public enum MusicType { MainMenuMusic = 0, InGameMusic };

    [SerializeField] private AudioClip[] Clips;
    [SerializeField] private float[] ClipsLength;

    private MusicType curMusicType;
    private float curTime = 0;

    public static MusicManager Instance;

    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        Instance = this;



        audioSource = GetComponent<AudioSource>();

        //volume = (PlayerPrefs.HasKey("MUSIC_VOLUME")) ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : volume;
        //volume *= volumeK;
            
        curTime = 0;
        ChangeMusic(MusicType.MainMenuMusic);

        for (int i = 0; i < Clips.Length; i++)
        {
            ClipsLength[i] = Clips[i].length;
        }

    }

    public void ChangeVolume(float newVolume)
    {

        volume = newVolume;
        volume *= volumeK;

    }

    private void Update()
    {
        curTime += Time.unscaledDeltaTime;

        if (curTime > ClipsLength[(int)curMusicType] - 1)
        {
            curTime = 0;
            ChangeMusic(curMusicType);
        }
    }

    public void ChangeMusic(MusicType type)
    {
        audioSource.clip = Clips[(int)type];
        audioSource.Play();
        curTime = 0;
        curMusicType = type;
    }

}
