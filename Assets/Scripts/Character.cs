using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int health;
    public int Health{
        get { return health; }
        set { health = ( value < 0) ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;
    

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage} Current Health : {Health} ");

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
