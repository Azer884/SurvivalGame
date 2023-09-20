using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller ;
    public float speed = 10f;
    public float gravity = -10f;
    public Transform GroundCheck;
    private bool IsGrounded;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    private bool Isjummping = false;
    public float Jump = 3.2f;
    public float Sprint = 1.33f;
    Vector3 velocity;
    public Enemy Health;
    public float SprintUsage = 2f;
    public float JumpUsage = 5f;
    public Animator JumpAnim ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position , groundDistance , GroundMask );

        float horizontal = Input.GetAxis("Horizontal") * 0.5f ;
        float vertical = Input.GetAxis("Vertical") * 0.75f;
        if (vertical <= -0.5f)
        {
            vertical = -0.5f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (vertical > 0)
            {
                if (Health.currentHealth > 20f)
                {
                    vertical *= Sprint  ;
                    Health.currentHealth -= SprintUsage * Time.deltaTime;
                }
                else
                {
                    Debug.Log("U r to low of HP");
                }
            }
        }
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        
        controller.Move(move * speed * Time.deltaTime);  
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (IsGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            Isjummping = false;
            JumpAnim.SetBool("IsGrounded" , true); 
        }

        if (Input.GetButtonDown("Jump") && !Isjummping)
        {
            if (IsGrounded)
            {
                if (Health.currentHealth > 20f)
                {
                    velocity.y = Jump ;
                    Health.currentHealth -= JumpUsage;
                    JumpAnim.SetBool("IsGrounded" , false);
                }
                else
                {
                    Debug.Log("U r to low of HP");
                }
            }
            else
            {
                Isjummping = true ;
            }
        }
    }
}
