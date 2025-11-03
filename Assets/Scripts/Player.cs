using UnityEngine;
using UnityEngine.Windows;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    [SerializeField] private float moveSpeed = 5f;
    private float inputX;
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public int maxHealth = 100;
    internal Vector2 position;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            //take damage
        }



    }




    public void Shoot()
    {
        if (UnityEngine.Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(20, this);

                WaitTime = 0.0f;



        }
    }


    private void Flip(float direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction);
        transform.localScale = scale;
    }



    public override void Behavior()
    {
        inputX = UnityEngine.Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(inputX * moveSpeed, rb.linearVelocity.y);

        if (inputX != 0) Face(inputX);

        if (anim) anim.SetFloat("Speed", Mathf.Abs(inputX));
    }

    private void Face(float dir)
    {
        var s = transform.localScale;
        s.x = Mathf.Abs(s.x) * Mathf.Sign(dir);   
        transform.localScale = s;
    }

    private void Update()
    {
        Shoot();
        Behavior();
    }




}