using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    [SerializeField] Transform[] MovePoint;

    [SerializeField] private int contactDamage = 20;     
    [SerializeField] private float hitInterval = 1f;
    private float nextAttackTime;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        DamageHit = contactDamage;
        velocity = new Vector2(-1.0f, 0.0f);
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (velocity.x < 0 && rb.position.x <= MovePoint[0].position.x)
        {
            Flip();
        }

        if (velocity.x > 0 && rb.position.x >= MovePoint[1].position.x)
        {
            Flip();
        }

    }

    void Flip()
    {
        velocity.x *= -1;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    private void FixedUpdate()
    {
        Behavior();
    }




    void OnCollisionStay2D(Collision2D col)
    {
        TryDamage(col.collider);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        TryDamage(other);
    }


    void TryDamage(Collider2D hit)
    {
        if (Time.time < nextAttackTime)
        {
            return;
        }

        var player = hit.GetComponentInParent<Player>();
        if (player == null)
        {
            return;
        }

        player.TakeDamage(contactDamage);
        nextAttackTime = Time.time + hitInterval;
    }





    
}
