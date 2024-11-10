using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    private float _moveSpeed = 5f;
    private float _rotationSpeed = 8;
    private float _decelerationFactor = .9f;
    private bool _enableMove =true;
    

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float RotationSpeed { get { return _rotationSpeed; } set { _rotationSpeed = value; } }
    public bool EnableMove {  get { return _enableMove; } set { _enableMove = value; } }


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_enableMove)
        {
            Move();
        }
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xInput, 0, zInput).normalized;
        if (moveDirection != Vector3.zero)
        {
            Vector3 targetVelocity = moveDirection * _moveSpeed;
            playerRb.linearVelocity = new Vector3(targetVelocity.x, playerRb.linearVelocity.y, targetVelocity.z);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
        else
        {
            playerRb.linearVelocity = new Vector3(
                Mathf.Lerp(playerRb.linearVelocity.x, 0, _decelerationFactor),
                playerRb.linearVelocity.y,
                Mathf.Lerp(playerRb.linearVelocity.z, 0, _decelerationFactor)
                );
        }
    }


}
