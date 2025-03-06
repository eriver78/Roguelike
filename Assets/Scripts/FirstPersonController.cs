using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{

    private Vector2 direction, pointer;
    private CapsuleCollider col;
    private Rigidbody rb;
    private Vector3 camRotation;

    private bool crouch = false, slide = false, onGround = true, second = true;

    [SerializeField] private Transform cam, legs;
    [SerializeField] Animator anim;
    [SerializeField] private float speed, crouchSpeed, sensitivity, dashLength, slideBoost, jumpHeight;


    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        camRotation = cam.transform.localEulerAngles;
    }

    void Update()
    {
        anim.SetBool("Move", direction != Vector2.zero);
        anim.SetBool("Slide", slide);
        transform.eulerAngles += new Vector3(0, pointer.x * sensitivity, 0);
        camRotation.x -= pointer.y * sensitivity;
        camRotation.x = Mathf.Clamp(camRotation.x, -90, 90);
        cam.transform.localEulerAngles = camRotation;
        Vector3 vel = transform.forward * direction.y + transform.right * direction.x;
        if (crouch)
        {
            if (slide)
            {
                Vector3 vel2 = rb.linearVelocity;
                vel2.y = 0;
                vel = (transform.forward * direction.y + transform.right * direction.x) * vel2.magnitude;
                vel.y = rb.linearVelocity.y;
                rb.linearVelocity = vel;
            } else
            {
                vel *= crouchSpeed;
                vel.y = rb.linearVelocity.y;
                rb.linearVelocity = vel;
            }
        } else
        {
            vel *= speed;
            vel.y = rb.linearVelocity.y;
            rb.linearVelocity = vel;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        pointer = context.ReadValue<Vector2>();
    }

    

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (onGround) {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            onGround = false;
        } else if (second)
        {
            Vector3 vel = rb.linearVelocity;
            vel.y = 0;
            rb.linearVelocity = vel;
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            second = false;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (Physics.Raycast(transform.position, transform.forward, dashLength)) return;
        transform.position += transform.forward * dashLength;
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.started) return;
        crouch = context.performed;
        if (!crouch)
        {
            slide = false;
            transform.position += new Vector3(0, 0.5f, 0);
            col.height = 2;
            legs.transform.localPosition = Vector3.zero;
        }
        else
        {
            slide = direction != Vector2.zero;
            col.height = 1;
            legs.transform.localPosition = new Vector3(0, 0.5f, 0);
            if (slide)
            {
                rb.linearVelocity += (transform.forward * direction.y + transform.right * direction.x) * slideBoost;
            }
            transform.position -= new Vector3(0, 0.5f, 0);
        }
    }

    public void Ground()
    {
        onGround = true;
        second = true;
    }

    public void SlideOut()
    {
        onGround = false;
    }
}
