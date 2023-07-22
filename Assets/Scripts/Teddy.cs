using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Teddy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    public LayerMask layerMask;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = target.position;
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
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
        SetTarget(transform);
    }
}
