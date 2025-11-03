using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected int maxHp = 100;

    private int health;
    public int Health {
        get { return health; }
        set { health = (value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;
    protected HealthBar healthBar;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBar = GetComponentInChildren<HealthBar>(true);
    }


    protected virtual void Start()
    {
        Intialize(maxHp);
    }


    public void Intialize(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is initialed Health : {this.Health}");

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(startHealth); 
            healthBar.SetHealth(Health);
        }


    }
    

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage} Current Health : {Health} ");

        if (healthBar != null)
        {
            healthBar.SetHealth(Health);
        }

        IsDead();
    }


    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else {return false;}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
