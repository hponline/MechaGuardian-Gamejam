using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("References")]
    [SerializeField] InputHandler inputHandler;

    public Transform cameraTransform;

    [Header("Variables")]
    public float speedWalk = 10f;
    public bool isWalking = false;    
    public float rotationSpeed = 10f;


    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        PlayerMovement();
        RotateTowardsMouse();     
    }

    void PlayerMovement()
    {
        Vector2 inputVector = inputHandler.GetMoveDirection();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDirection.sqrMagnitude > 0.0001f)
        {
            transform.position += moveDirection.normalized * speedWalk * Time.deltaTime;
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void RotateTowardsMouse()
    {
        if (Camera.main == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(
            Mouse.current.position.ReadValue()
        );

        // Y düzlemi (zemin)
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        if (!groundPlane.Raycast(ray, out float enter))
            return;

        Vector3 mouseWorldPos = ray.GetPoint(enter);
        Vector3 lookDir = mouseWorldPos - transform.position;
        lookDir.y = 0f;

        if (lookDir.sqrMagnitude < 0.001f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    
    
}
