using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector2 bouncFactor;
    public static PlayerControl instance;
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;
    public GameObject lrObject;
    public static Action OnMove;
    Vector3 dragStartPos;
    Touch touch;
    private bool isMoving;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !isMoving)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRealease();
            }
        }


    }
    private void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    private void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }
    private void DragRealease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        Debug.Log("DragRealseased");
        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        rb.AddForce(clampedForce, ForceMode2D.Impulse);

        OnMove?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.contactCount);
        foreach (var col in collision.contacts)
        {
            if (col.normal == Vector2.up)
            {
                rb.velocity = Vector3.zero;
                break;
            }
            else if (col.normal == Vector2.down)
            {
                continue;
            }
            else
            {
                rb.AddForce(new Vector2(-rb.velocity.x * bouncFactor.x, rb.velocity.y * bouncFactor.y));
            }
        }
    }
}
