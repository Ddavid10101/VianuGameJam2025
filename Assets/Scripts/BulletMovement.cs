using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    [SerializeField] float BulletSpeed;
    float BulletMaxTime,BulletCurrentTime;

    private void Awake()
    {
        BulletMaxTime = GeneralStats.Instance.Range / BulletSpeed;
        transform.localScale = Vector3.one * GeneralStats.Instance.BulletSize;
    }


    void Update()
    {
        MoveBullet();
        BulletCurrentTime += Time.deltaTime;
        if (BulletCurrentTime > BulletMaxTime)
            Destroy(gameObject);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        { Destroy(gameObject); }
    }

    private void MoveBullet()
    {
        transform.Translate(Vector2.right * BulletSpeed * Time.deltaTime);
    }

    
}
