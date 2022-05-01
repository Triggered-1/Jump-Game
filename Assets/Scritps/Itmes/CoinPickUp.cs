using UnityEngine;

public class CoinPickUp : Interactable
{
    public int coinAmount;

    public override void Interact(PlayerStats inventory)
    {
        base.Interact(inventory);

        PickUp(inventory);
    }

    void PickUp(PlayerStats inventory)
    {
        Debug.Log("Picking Up " + coinAmount);
        inventory.AddCoins(coinAmount);
        Destroy(gameObject);
    }
}
