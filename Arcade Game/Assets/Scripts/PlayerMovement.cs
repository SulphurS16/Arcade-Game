using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float aimSpeed;   
    
    [SerializeField] private float shootSpeed;

    [SerializeField] private bool useSmoothAim;

    [SerializeField] private ParticleSystem ps;

    private Rigidbody2D rb;
    private float aimAngle;
    private bool canshoot = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        Vector2 aimInput = new Vector2(Input.GetAxisRaw("AimY"), Input.GetAxisRaw("AimX"));
        input.Normalize();
        if (aimInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg;
            if(useSmoothAim)
            {
            aimAngle = Mathf.MoveTowards(aimAngle, angle, aimSpeed);
            }
            else { aimAngle = angle; }

            transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);

            Debug.DrawRay(transform.position, transform.up);
            if (canshoot)
                StartCoroutine(Shoot(aimInput));
        }
        if (input != Vector2.zero)
        {
            rb.MovePosition(rb.position + input * speed * Time.deltaTime);
        }
    }

    private IEnumerator Shoot(Vector2 direction)
    {
        canshoot = false;
        ps.Emit(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        if (hit != false)
        {
        Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("Zombie"))
            {
                hit.collider.GetComponent<Health>().Damage(1);
            }
        }
            yield return new WaitForSeconds(shootSpeed);
            canshoot = true;
    }
}
