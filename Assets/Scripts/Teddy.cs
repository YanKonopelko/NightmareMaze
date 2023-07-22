using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Teddy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetTarget(other.transform);
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
        yield return new WaitForSeconds(3);
        SetTarget(transform);
    }
}
