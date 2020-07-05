using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ARMenu_ProductSelector : MonoBehaviour
{
    private ProductList selectedProductList;
    private Product selectedProduct;
    private string selectedProductType;
    bool isProductListReloaded = false;
    bool isProductReloaded = false;

    public GameObject UISelectionContainer;
    public GameObject UISelectionOption;
    public GameObject UIInformationPanel;

    public GameObject ProductModelSpawnPoint;

    public ProductList centralPanelProductList;
    public ProductList corniceProductList;

    void Start ()
    {
      selectedProductType = "central-panel";
      selectedProductList = centralPanelProductList;
      LoadProduct(new Product());
    }

    void Update ()
    {
        if (isProductListReloaded == false)
        {
            LoadProductList();
        }

        if (isProductReloaded == false)
        {
            LoadSelectedProductInfo();
        }
    }

    public void LoadStartUpProduct ()
    {
        LoadProduct(selectedProductList.productList[0]);
        isProductListReloaded = true;
    }

    public void EmptyProductDisplay ()
    {
        LoadProduct(new Product());
    }

    public void ToggleProductType (Button sourceButton)
    {
        Text buttonLabelText = sourceButton.GetComponentInChildren<Text>();

        if (selectedProductType == "central-panel")
        {
            buttonLabelText.text = "Cornice";
            selectedProductType = "cornice";
            selectedProductList = corniceProductList;
            isProductListReloaded = false;
            return;
        }

        if (selectedProductType == "cornice")
        {
            buttonLabelText.text = "Central Panel";
            selectedProductType = "central-panel";
            selectedProductList = centralPanelProductList;
            isProductListReloaded = false;
            return;
        }

        buttonLabelText.text = "UNKNOWN";
        selectedProductType = "unknown";
        isProductListReloaded = false;
    }

    private void LoadProductList ()
    {
        ClearProductList();
        foreach (Product product in selectedProductList.productList)
        {
            GameObject newProductSelectionOption = Instantiate(UISelectionOption);
            Button btn = newProductSelectionOption.GetComponent<Button>();

            btn.GetComponentInChildren<Text>().text = product.name;
            newProductSelectionOption.GetComponent<Transform>()
              .Find("IMG_ProductSelection")
              .GetComponent<Image>()
              .sprite = product.image;

            newProductSelectionOption.transform.position = UISelectionContainer.transform.position;
            newProductSelectionOption.GetComponent<RectTransform>().SetParent(UISelectionContainer.transform);
            newProductSelectionOption.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 300, 300);
            btn.onClick.AddListener(() => LoadProduct(product));
        }
        isProductListReloaded = true;
    }

    private void LoadProduct (Product product)
    {
        selectedProduct = product;
        GameObject productModel = Instantiate(product.model);
        Transform productModelTransform = productModel.GetComponent<Transform>();

        foreach (Transform childObject in ProductModelSpawnPoint.transform)
        {
            GameObject.Destroy(childObject.gameObject);
        }

        productModel.transform.position = ProductModelSpawnPoint.transform.position;
        productModelTransform.SetParent(ProductModelSpawnPoint.transform);
        productModelTransform.localScale = new Vector3(100, 100, 100);

        isProductReloaded = false;
    }

    private void LoadSelectedProductInfo ()
    {
        string productType = "UNKNOWN";
        string productLabel = selectedProduct.name + " - " + (selectedProduct.width/100) + "m x " + selectedProduct.height + "cm";

        if (selectedProductType == "central-panel")
        {
            productType = "Central Panel";
            productLabel = selectedProduct.name + " - " + selectedProduct.width + "cm x " + selectedProduct.height + "cm";
        }

        if (selectedProductType == "cornice")
        {
            productType = "Cornice";
        }

        GameObject productTypeTxt = UIInformationPanel.transform.Find("PNL_TXT_ProductType").gameObject;

        productTypeTxt.transform.Find("TXT_ProductTypeShadow").GetComponent<Text>().text = productType;
        productTypeTxt.transform.Find("TXT_ProductType").GetComponent<Text>().text = productType;

        GameObject productNameTxt = UIInformationPanel.transform.Find("PNL_TXT_ProductName").gameObject;

        productNameTxt.transform.Find("TXT_ProductNameShadow").GetComponent<Text>().text = productLabel ;
        productNameTxt.transform.Find("TXT_ProductName").GetComponent<Text>().text = productLabel;

        isProductReloaded = true;
    }

    private void ClearProductList ()
    {
        foreach (Transform childUIObject in UISelectionContainer.GetComponent<RectTransform>())
        {
            Destroy(childUIObject.gameObject);
        }
    }
}
