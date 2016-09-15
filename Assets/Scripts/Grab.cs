using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Grab : MonoBehaviour
{
    private Rigidbody2D rb;
    private HingeJoint2D joint;

    private bool dragging = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            joint.connectedBody = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.position = mousePos;

            RaycastHit2D hit = Physics2D.Raycast(new Vector3(mousePos.x, mousePos.y, -10f), Vector3.forward);
            Rigidbody2D hitBody = hit.rigidbody;

            if(hitBody != null/* && hitBody.gameObject.layer == LayerMask.NameToLayer("Stickman")*/)
            {
                dragging = true;
                joint.connectedBody = hitBody;
            }
        }

        if(dragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(Vector3.Lerp(rb.position, mousePos, 0.25f));
        }
    }
}
