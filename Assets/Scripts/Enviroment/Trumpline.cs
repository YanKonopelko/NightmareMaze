using System.Threading.Tasks;
using UnityEngine;

public class Trumpline : MonoBehaviour
{
    [SerializeField] private float force = 12;
    private CharacterController characterController;
    private Rigidbody rb ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            SoundManager.Instance.PlaySound(SoundManager.SoundType.TrumpolineSound, transform.position);

            rb = other.gameObject.GetComponent<Rigidbody>();
            characterController = other.gameObject.GetComponent<CharacterController>();

            characterController.enabled = false;
            rb.useGravity = true;

            rb.velocity = Vector3.up*force ;

            ReturnPlayerControl();
        }
    }

    private async void ReturnPlayerControl()
    {
        while(rb.velocity.y > 0)
        {
            await Task.Delay(16);
        }
        rb.useGravity = false;
        characterController.enabled = true;
    }


}
