using UnityEngine;

public class Ant :  Enemy
{
    [SerializeField] Vector2 velocity;
    [SerializeField] Transform[] MovePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        DamageHit = 20;
        velocity = new Vector2(-1.0f , 0.0f);
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


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
    }
}
