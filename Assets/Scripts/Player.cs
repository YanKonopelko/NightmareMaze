using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public int StartHitPoints;

    private int _currentHitPoints;

    private bool isSlowed = false;

    private ThirdPersonController Controller;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Controller = GetComponent<ThirdPersonController>();
        _currentHitPoints = StartHitPoints;
    }
    public void DealDamage(int damage)
    {
        CameraController.instance.FadeOut();

        animator.SetTrigger("Trigger Hit");
        _currentHitPoints -= damage;
        Debug.Log("Damaged");
        if (_currentHitPoints < 1)
        {
            Kill();
        }
    }

    public void Kill()
    {
        GameManager.Instance.Load();
    }
    public void ChangeSpeed(bool isSlow)
    {
        Controller.speedModifier =  isSlow ? 0.65f : 1;
    }

    public void Heal(int healCount)
    {
        _currentHitPoints = Mathf.Clamp(_currentHitPoints + healCount,0, StartHitPoints);
    }

    public void Jump() {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }
}