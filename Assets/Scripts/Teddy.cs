using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Teddy : MonoBehaviour
{
    private NavMeshAgent agent;

    private Vector3 startPos;
    [SerializeField] private Transform target;
    public Transform FollowingPos;
    public LayerMask layerMask;

    private Rigidbody rb;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
        GameManager.Instance.OnReload += Restart;
        rb = GetComponent<Rigidbody>();
        target = transform;
    }

    void Update()
    {
        agent.destination = target.position;
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Kill();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Eb");
            Vector3 dir = other.transform.position - transform.position;
            dir.y = transform.position.y;
            Ray ray= new Ray(transform.position,dir);
            RaycastHit hit;

            Physics.Raycast(ray, out hit,1000,layerMask);
            if(hit.collider.tag == "Player") {
                StopAllCoroutines();
                SetTarget(other.transform);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(StopFollowing());
        }
    }

    IEnumerator StopFollowing()
    {
        yield return new WaitForSeconds(6);
        SetTarget(FollowingPos);
    }

    private void Restart()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPos;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnReload -= Restart;
    }
}
