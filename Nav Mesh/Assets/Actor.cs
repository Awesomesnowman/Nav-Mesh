using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy1 : MonoBehaviour
{
    public GameObject Goal1;
    public GameObject Goal2;
    Vector3 goal1;
    Vector3 goal2;
    GameObject player;
    RaycastHit check;
    NavMeshAgent myNav = null;
    public int goal = 1;
    public Rigidbody myRig;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Human");
        myNav = this.gameObject.GetComponent<NavMeshAgent>();
        goal1 = Goal1.transform.position;
        goal2 = Goal2.transform.position;
        myNav.SetDestination(goal2);
        myNav.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform.position);
        Physics.Raycast(this.transform.position, this.transform.forward, out check);
        if (check.collider.tag == "Player" && check.distance <= 10)
        {
            myNav.SetDestination(player.transform.position);
        }
        else
        {
            if (goal == 0)
                myNav.SetDestination(goal1);
            else
                myNav.SetDestination(goal2);
            if (myNav.remainingDistance == 0 && goal == 0)
            {
                goal += 1;
                myNav.SetDestination(goal2);
                myNav.isStopped = false;
            }
            else if (myNav.remainingDistance == 0 && goal == 1)
            {
                goal -= 1;
                myNav.SetDestination(goal1);
                myNav.isStopped = false;
            }
        }

    }
}
