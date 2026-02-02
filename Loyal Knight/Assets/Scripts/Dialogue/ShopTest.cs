using UnityEngine;

public class ShopTest : MonoBehaviour
{
    public void OpenShop()
    {
        Debug.Log("Shop Openend");
        CloseShop();
    }

    public void CloseShop()
    {
        Debug.Log("Shop closed");
    }
}
