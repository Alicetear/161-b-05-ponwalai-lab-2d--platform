using UnityEngine;

public class Crocodlie : Enemy, IShootable
{
    [SerializeField] float atkRange;
    public Player player;

    public GameObject Bullet { get; set; }
    public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(50);
        DamageHit = 30;

        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0;
        ReloadTime = 5f;
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
        Debug.Log($"{this.name} shoots rock to the {player.name}!");
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }
}
