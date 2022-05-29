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
            GameManager.Instance.ShowText($"Added +{pesosAmount} pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
    }
}
