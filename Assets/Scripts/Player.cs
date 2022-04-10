using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Awake()
    {
        // GameObject.DontDestroyOnLoad(this);
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        // transform.Translate(moveDelta * Time.deltaTime);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.fixedDeltaTime), LayerMask.GetMask("Blocking", "Actor"));

        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.fixedDeltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.fixedDeltaTime), LayerMask.GetMask("Blocking", "Actor"));

        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.fixedDeltaTime, 0, 0);
        }
    }
}
