using UnityEngine;

public class Crocodlie : Enemy, Ishootable
{
    [SerializeField] float atkRange;
    public Player player;



    public float ReloadTime { get; set; }

    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(50);
        DamageHit = 30;

        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0.0f;
        ReloadTime = 5.0f;
    }

    private override void FixedUpdate()
    {
        WaitTime += WaitTime.fixedDeltaTime;
        Behavior();
    }



    public override void Behavior()
    {
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
        }
        Debug.Log($"{this.name} shoots rock to the {player.name}!");
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }
}
