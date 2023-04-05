using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP_Donations : MonoBehaviour
{
    private IStoreController storeController;
    private IExtensionProvider extensionProvider;
    public GameObject menu;

    private void Start()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("donation_1", ProductType.Consumable);
        builder.AddProduct("donation_2", ProductType.Consumable);
        builder.AddProduct("donation_3", ProductType.Consumable);
        builder.AddProduct("donation_4", ProductType.Consumable);
        builder.AddProduct("donation_5", ProductType.Consumable);
        builder.AddProduct("donation_6", ProductType.Consumable);
        builder.AddProduct("donation_7", ProductType.Consumable);
        builder.AddProduct("donation_8", ProductType.Consumable);
        builder.AddProduct("donation_9", ProductType.Consumable);
        builder.AddProduct("donation_10", ProductType.Consumable);
        //UnityPurchasing.Initialize((IStoreListener)this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        extensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError(error.ToString());
    }

    public void donationAmountConverter()
    {
        int amnt = menu.GetComponent<Menu>().getDon();
        string id = "donation_" + amnt;
        Debug.Log(id);
        PurchaseDonation("donation_"+amnt);
    }
    public void PurchaseDonation(string productId)
    {
        if (storeController != null)
        {
            storeController.InitiatePurchase(productId);
        }
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // Handle purchase failure here.
    }
}
