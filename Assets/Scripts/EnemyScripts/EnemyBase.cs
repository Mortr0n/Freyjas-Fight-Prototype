using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Rigidbody enemyRb;
    public float _topSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(1, 0, 1).normalized;
        Vector3 targetVelocity = moveDirection * _topSpeed;
        enemyRb.linearVelocity = new Vector3(targetVelocity.x, enemyRb.linearVelocity.y, targetVelocity.z);
    }
}
