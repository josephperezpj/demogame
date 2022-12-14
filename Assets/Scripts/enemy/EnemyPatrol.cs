using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    public Animator anim;

    [SerializeField]
    private Transform[] waypoints;
    
    private int waypointIndex = 0;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;
    public bool mustChase;
    private bool mustSleep = false;

    [SerializeField]
    private Transform player;
    [SerializeField]
    public Color myColor;
   [SerializeField]
    private float agroRange = 3f;

    Vector2 direction;
    Vector2 targetDirection;
    Vector2 difference;
 


    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        mustPatrol = true;

        


    }

    private void Update()
    {



        if (mustSleep)
            return;

        CheckAgro();
        if (mustPatrol)
        {
            MoveAlongPath();
        }
        else if (mustChase)
        {
            ChasePlayer();
        }
         direction = new Vector2 (transform.position.x, transform.position.y).normalized;
         difference = targetDirection - direction;

     

         if(difference.x < 0){
            gameObject.transform.localScale = new Vector2 (-1,1);
         }

         
         if(difference.x > 0){
            gameObject.transform.localScale = new Vector2 (1,1);
         }
        

        
    }
 
    private void CheckAgro()
    {
        if (Vector2.Distance(transform.position, player.position) < agroRange && GameManagement.manager.playerHealth > 0)
        {
            mustChase = true;
            mustPatrol = false;
        }
        else
        {
            mustChase = false;
            mustPatrol = true;

        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed * Time.deltaTime);
        targetDirection = new Vector2 (player.transform.position.x, player.transform.position.y).normalized;
    }

    private void MoveAlongPath()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            walkSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.5f)
        {

            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        targetDirection = new Vector2 (waypoints[waypointIndex].transform.position.x, waypoints[waypointIndex].transform.position.y).normalized;
    }

        void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = myColor;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }
}
