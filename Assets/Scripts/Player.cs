using UnityEngine;

public class Player : MonoBehaviour
{
    public float speede;

    private Rigidbody2D rigi;
    private Animator anim;
    public GameObject player;

    public GameObject bomb;
    public Transform spawnposition;


    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float movement_h = Input.GetAxis("Horizontal");
        float movement_v = Input.GetAxis("Vertical");
        rigi.velocity = new Vector2(movement_h * speede, rigi.velocity.y);
        rigi.velocity = new Vector2(rigi.velocity.x, movement_v * speede);
        if(movement_h > 0f || movement_v != 0f)
        {
            anim.SetBool("Move",true);
        }
        else if(movement_h < 0f || movement_v != 0f)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }

        if (Input.GetKeyDown("j"))
        {
            Bomb();
        }

    }

    void Bomb()
    {
        bomb.GetComponent<Renderer>().enabled = true;
        bomb = Instantiate(bomb);
        bomb.transform.position = spawnposition.position;
        Destroy(bomb, 5);
        Animator animbomb = bomb.GetComponent<Animator>();
        animbomb.SetBool("Exploding", true);
    }




}