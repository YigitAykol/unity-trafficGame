/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject PATH;
    public Transform[] PathPoints;

    public float minDistance = 15;
    public int index = 0;

    //private Collider collider;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //collider = GetComponent<Collider>();
        // Initialize the array with the number of children under PATH
        PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PATH.transform.childCount; ++i)
        {
            PathPoints[i] = PATH.transform.GetChild(i);
        }
    }

    void Update()
    {
        roam();
    }

    void roam()
    {
        // Check if the current position is close enough to the target waypoint
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
        {
            // If not at the last point, move to the next point
            if (index < PathPoints.Length && index>=0 )
            {
                index += 1;
                WaitAtTrafficLight(3);
            }
            else
            {
                // If at the last point, reset to the first point
                index = 0;
            }
            
        }
        if(index == PathPoints.Length)
        {
            index = 0;
        }
        // Set the destination of the NavMeshAgent to the current waypoint
        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("vertical", !agent.isStopped?1:0);
    }

    
    public IEnumerator WaitAtTrafficLight(float waitTime)
    {
        agent.isStopped = true;
        animator.SetFloat("vertical", 0);
        animator.SetFloat("horizontal", 0);
        yield return new WaitForSeconds(waitTime);
        agent.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TTTT"))
        {
            Debug.Log("as   ");
        }


    }
}*/
/*asdasdasdas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour
{
   public NavMeshAgent agent;
   public Animator animator;

   public GameObject PATH;
   public Transform[] PathPoints;

   public float minDistance = 15;
   public int index = 0;

   private TrafficLight trafficLight;
   private bool isInTrafficLightArea = false;

   void Start()
   {
       agent = GetComponent<NavMeshAgent>();
       animator = GetComponent<Animator>();

       // Initialize the array with the number of children under PATH
       PathPoints = new Transform[PATH.transform.childCount];
       for (int i = 0; i < PATH.transform.childCount; ++i)
       {
           PathPoints[i] = PATH.transform.GetChild(i);
       }
   }

   void Update()
   {
       if (isInTrafficLightArea && trafficLight != null && trafficLight.IsRedLight())
       {
           agent.isStopped = true;
           animator.SetFloat("vertical", 0);
       }
       else
       {
           agent.isStopped = false;
           roam();
       }
   }

   void roam()
   {
       // Check if the current position is close enough to the target waypoint
       if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
       {
           // If not at the last point, move to the next point
           if (index < PathPoints.Length && index >= 0)
           {
               index += 1;
           }
           else
           {
               // If at the last point, reset to the first point
               index = 0;
           }
       }

       if (index == PathPoints.Length)
       {
           index = 0;
       }

       // Set the destination of the NavMeshAgent to the current waypoint
       agent.SetDestination(PathPoints[index].position);
       animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
   }

   public IEnumerator WaitAtTrafficLight(float waitTime)
   {
       agent.isStopped = true;
       animator.SetFloat("vertical", 0);
       yield return new WaitForSeconds(waitTime);
       agent.isStopped = false;
   }

   private void OnTriggerEnter(Collider other)
   {
       Debug.Log("Entered Traffic Light Area");
       if (other.CompareTag("TrafficLightArea"))
       {
           Debug.Log("Entered Traffic Light Area");
           trafficLight = other.GetComponentInParent<TrafficLight>();
           //bool isRed = trafficLight.IsRedLight();
           isInTrafficLightArea = true;

           if(trafficLight.IsRedLight())
           {
               Debug.Log("kirmizide");
           }

           //StartCoroutine(WaitAtTrafficLight(5f)); 
       }
   }

   private void OnTriggerExit(Collider other)
   {
       if (other.CompareTag("TrafficLightArea"))
       {
           Debug.Log("Exited Traffic Light Area");
           trafficLight = null;
           isInTrafficLightArea = false;
       }
   }
}*/
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject PATH;
    public Transform[] PathPoints;

    public float minDistance = 15;
    public int index = 0;

    private TrafficLight trafficLight;
    private bool isInTrafficLightArea = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Initialize the array with the number of children under PATH
        PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PATH.transform.childCount; ++i)
        {
            PathPoints[i] = PATH.transform.GetChild(i);
        }
    }

    void Update()
    {
        if (isInTrafficLightArea && trafficLight != null)
        {
            if (trafficLight.IsRedLight())
            {
                agent.isStopped = true;
                animator.SetFloat("vertical", 0);
                Debug.Log("NPC stopped at red light");
            }
            else
            {
                agent.isStopped = false;
                roam();
                Debug.Log("NPC moving at green light");
            }
        }
        else
        {
            roam();
        }
    }

    void roam()
    {
        // Check if the current position is close enough to the target waypoint
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
        {
            // If not at the last point, move to the next point
            if (index < PathPoints.Length && index >= 0)
            {
                index += 1;
            }
            else
            {
                // If at the last point, reset to the first point
                index = 0;
            }
        }

        if (index == PathPoints.Length)
        {
            index = 0;
        }

        // Set the destination of the NavMeshAgent to the current waypoint
        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
    }

    public IEnumerator WaitAtTrafficLight(float waitTime)
    {
        Debug.Log("NPC is waiting at traffic light for " + waitTime + " seconds.");
        agent.isStopped = true;
        animator.SetFloat("vertical", 0);
        yield return new WaitForSeconds(waitTime);
        agent.isStopped = false;
        isInTrafficLightArea = false; // NPC'nin tekrar hareket etmesini sağla
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrafficLightArea"))
        {
            Debug.Log("Entered Traffic Light Area");
            trafficLight = other.GetComponentInParent<TrafficLight>();
            isInTrafficLightArea = true;

            if (trafficLight != null && trafficLight.IsRedLight())
            {
                Debug.Log("Red light detected");
            }
            else
            {
                Debug.Log("Green light detected");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrafficLightArea"))
        {
            Debug.Log("Exited Traffic Light Area");
            trafficLight = null;
            isInTrafficLightArea = false;
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject PATH;
    public Transform[] PathPoints;

    public float minDistance = 15;
    public int index = 0;

    private TrafficLight trafficLight;
    private bool isInTrafficLightArea = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Initialize the array with the number of children under PATH
        PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PATH.transform.childCount; ++i)
        {
            PathPoints[i] = PATH.transform.GetChild(i);
        }
    }

    void Update()
    {
        if (isInTrafficLightArea && trafficLight != null)
        {
            if (trafficLight.IsRedLight())
            {
                agent.isStopped = false;
                roam();
                Debug.Log("NPC moving at red light");
            }
            else
            {
                agent.isStopped = true;
                animator.SetFloat("vertical", 0);
                Debug.Log("NPC stopped at green light");
            }
        }
        else
        {
            roam();
        }
    }

    void roam()
    {
        // Check if the current position is close enough to the target waypoint
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
        {
            // If not at the last point, move to the next point
            if (index < PathPoints.Length && index >= 0)
            {
                index += 1;
            }
            else
            {
                // If at the last point, reset to the first point
                index = 0;
            }
        }

        if (index == PathPoints.Length)
        {
            index = 0;
        }

        // Set the destination of the NavMeshAgent to the current waypoint
        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
    }

    public IEnumerator WaitAtTrafficLight(float waitTime)
    {
        Debug.Log("NPC is waiting at traffic light for " + waitTime + " seconds.");
        agent.isStopped = true;
        animator.SetFloat("vertical", 0);
        yield return new WaitForSeconds(waitTime);
        agent.isStopped = false;
        isInTrafficLightArea = false; // NPC'nin tekrar hareket etmesini sağla
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrafficLightArea"))
        {
            Debug.Log("Entered Traffic Light Area");
            trafficLight = other.GetComponentInParent<TrafficLight>();
            isInTrafficLightArea = true;

            if (trafficLight != null && trafficLight.IsRedLight())
            {
                Debug.Log("Red light detected");
            }
            else
            {
                Debug.Log("Green light detected");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrafficLightArea"))
        {
            Debug.Log("Exited Traffic Light Area");
            trafficLight = null;
            isInTrafficLightArea = false;
        }
    }
}







/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    
    public GameObject PATH;
    public Transform[] PathPoints;

    public float minDistance = 10;
    // Start is called before the first frame update
    public int index=0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        animator = GetComponent<Animator>();

        PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PATH.Length; ++i)
        {
            PathPoints[i]=PATH.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        roam();
    }

    void roam() {

        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)   
        {
            if (index < 0 && index < PathPoints.Length)
            {
                index += 1;
            }
            else 
            {
                index= 0;
            }
        }

        agent.SetDestination(PathPoints[index].position);
    }
}*/
