using UnityEngine;
public class Interactable : MonoBehaviour
{
    private Transform player;

    public virtual void Interact()
    {
        Debug.Log("Interacting with" + transform.name);
    }
    public virtual void Interact(PlayerStats inventory)
    {
        Debug.Log("Interacting with" + transform.name);
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerControl>().transform;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interact(collision.GetComponent<PlayerStats>());
        }
    }
}
