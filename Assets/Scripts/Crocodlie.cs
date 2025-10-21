using UnityEngine;

public class Crocodlie : Enemy
{
    [SerializeField] float atkRange;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(50);

        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
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

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }
}
