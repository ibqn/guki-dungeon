using UnityEngine;

public class Chest : Collectable
{
    [SerializeField]
    private Sprite emptyChest;

    [SerializeField]
    private int pesosAmount = 10;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            Debug.Log($"collected {pesosAmount} pesos");
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
    }
}
