using UnityEngine;
using UnityEngine.SceneManagement;


public class Hero : DamageControll
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public static Hero Instance { get; set; }





    //скорость персонажа
    [SerializeField] private float speed = 3f;
    //количество жизней
    [SerializeField] private int lives = 5;
    //Сила прыжка
    [SerializeField] private float jumpForce = 15f;





    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Update()
    {

        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump"))
            Jump();

    }


    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }



    private void Aweke()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public enum States
    {
        idle,
        run
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }


    public override void GetDamage()
    {
        lives -= 1;
        if (lives == 0)
        {
            SceneManager.LoadScene(4);
        }

        Debug.Log(lives);

    }





}
