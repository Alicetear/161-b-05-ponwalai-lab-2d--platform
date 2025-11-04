using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;

    }

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this.damage);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 0.5f * GetShootDitection();
        damage = 10;

    }

    private void FixedUpdate()
    {
        Move();
    }


    void Update()
    {
        Move();
    }


}