using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed;
    private float horizontal;

    public float fuerzaSalto = 10f;
    public float longitudRayCast = 0.1f;
    public LayerMask capaSuelo;

    private bool enSuelo;
    private Rigidbody2D rd;
    private Animator Animator;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        Animator.SetBool("running", horizontal != 0.0f);

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Vector2 posicion = transform.position;

        transform.position = new Vector2(posicion.x + horizontal, posicion.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRayCast, capaSuelo);
        enSuelo = hit.collider != null;

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rd.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRayCast);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Score++;
            Destroy(other.gameObject);
        }
    }
}
