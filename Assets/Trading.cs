using UnityEngine;

public class Trading : MonoBehaviour
{
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject inventoryPanel;
    Store store;
    Currency money; 
    

    private void Awake()
    {
        money = GetComponent<Currency>();
    }

    public void BeginTrading(Store store)
    {
        this.store = store;

        storePanel.SetActive(true);
        inventoryPanel.SetActive(true);

    }

    public void SellItem()
    {
        if (GameManager.instance.dragandDropController.CheckForSale() == true)
        {
            ItemSlot itemToSell = GameManager.instance.dragandDropController.itemSlot;
            int moneyGain = itemToSell.item.stackable == true ?
                itemToSell.item.price * itemToSell.count :
                itemToSell.item.price;
            money.Add(moneyGain);
            itemToSell.Clear();
        }
    }
}
