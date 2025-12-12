using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("References")]
    [SerializeField] InputHandler inputHandler;
    public Transform cameraTransform;

    [Header("Variables")]
    public float speedWalk = 3f;
    //public float cameraRotateSpeed = 3f;
    //public float mouseAffectRadius = 2f;
    public bool isWalking = false;
    public bool isAttack = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        PlayerMovement();
        //CameraMouseFollow();
        // wasd ile gidiyoruz mausun baktýgý yön karakterin z ekseni oluyor 
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

    //void CameraMouseFollow()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    //    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

    //    if (!groundPlane.Raycast(ray, out float enter))
    //        return;

    //    Vector3 mouseWorldPos = ray.GetPoint(enter);

    //    float distance = Vector3.Distance(mouseWorldPos, transform.position);
    //    if (distance > mouseAffectRadius)
    //        return;

    //    Vector3 lookDirection = (mouseWorldPos - transform.position);
    //    lookDirection.y = 0;

    //    if (lookDirection.sqrMagnitude < 0.001f)
    //        return;

    //    Quaternion targetRot = Quaternion.LookRotation(lookDirection);

    //    cameraTransform.rotation = Quaternion.Slerp(
    //        cameraTransform.rotation,
    //        targetRot,
    //        Time.deltaTime * cameraRotateSpeed
    //    );
    //}

    public void PlayerAttack()
    {
        if (!isAttack) return;
    }
}
