using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private int maxFadeCount = 5;
    private int curFadeCount = 0;

    //[SerializeField] private PostProcessVolume postProcess;
    [SerializeField] private float curIntensity = 0.1f;
    [SerializeField] private float needIntensity;

    [SerializeField] private Volume volume;
    [SerializeField] private Vignette vignette;

    [SerializeField] private float minIntensity;

    [SerializeField] private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        volume.sharedProfile.TryGet<Vignette>(out vignette);

    }

    public void FadeOut()
    {
        Debug.Log("Faded");
        curFadeCount++;

        needIntensity = Mathf.Max(minIntensity, needIntensity + 0.2f);
        
    }

    private void Update()
    {
        curIntensity =  Mathf.Lerp(curIntensity,needIntensity , 0.1f);
        curIntensity = curve.Evaluate(curIntensity);



        vignette.intensity.value = curIntensity;

    }

    public void Reload()
    {
        vignette.intensity.value = 0;
        curIntensity = 0;
        needIntensity = 0;
        curFadeCount = 0;
        needIntensity = 0;
    }


    private void OnEnable()
    {
        GameManager.Instance.OnReload += Reload;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnReload -= Reload;
    }
}
