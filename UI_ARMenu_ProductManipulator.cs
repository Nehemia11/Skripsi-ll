using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ARMenu_ProductManipulator : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;

    protected GameObject productModel;
    protected string selectedSizeMode = "ar-size";
    protected bool isReloadProductSizing = true;
    protected Plane productModelPlane;

    public GameObject productModelSpawnPoint;
    public GameObject productModelSizingButton;

    private void Start()
    {
        InitializeComponentReference();
    }

    private void Update()
    {
        WatchTouchInput();

        if (isReloadProductSizing)
        {
          ResizeProduct();
        }
    }

    private void InitializeComponentReference ()
    {
        Transform[] childObjects = productModelSpawnPoint.GetComponentsInChildren<Transform>();

        productModel = childObjects[0].gameObject;
        productModelPlane = productModel.GetComponent<Plane>();
    }

    private void WatchTouchInput ()
    {
        if (Input.touchCount >= 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if(touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled
               || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }

            if(touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = productModel.transform.localScale;
                return;
            }
            float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            if(Mathf.Approximately(initialDistance, 0))
            {
                return;
            }

            float factor = currentDistance / initialDistance;
            productModel.transform.localScale = initialScale * factor;

            productModelSizingButton.GetComponentInChildren<Text>().text = "Cust\nSize";
            selectedSizeMode = "custom-size";
            isReloadProductSizing = true;
        }

        // if ((Input.touchCount == 0) && (Input.touches.Length > 0))
        // {
        //     Touch touch = Input.touches[0];
        //     Ray ray = Camera.main.ScreenPointToRay(touch.position);
        //     RaycastHit hit;
        //
        //     if ( Physics.Raycast(ray, out hit, 100f ) )
        //     {
        //         productModel = hit.collider.gameObject;
        //         selectedSizeMode = "custom-size";
        //         isReloadProductSizing = true;
        //     }
        // }
        // if (Input.touchCount == 2)
        // {
        //     Touch touchZero = Input.GetTouch(0);
        //     Touch touchOne = Input.GetTouch(1);
        //
        //     Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //     Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
        //
        //     float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //     float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
        //
        //     float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
        //
        //     productModel.transform.localScale = new Vector3(deltaMagnitudeDiff , deltaMagnitudeDiff , deltaMagnitudeDiff);
              // productModelSizingButton.GetComponentInChildren<Text>().text = "Cust\nSize";
              // selectedSizeMode = "custom-size";
              // isReloadProductSizing = true;
        // }
    }

    private Vector3 ProductModelPositionDelta (Touch touch)
    {
        if (touch.phase != TouchPhase.Moved)
        {
            return Vector3.zero;
        }

        Ray rayBefore = Camera.main.ScreenPointToRay(touch.position - touch.deltaPosition);
        Ray rayNow = Camera.main.ScreenPointToRay(touch.position);

        if (productModelPlane.Raycast(rayBefore, out float enterBefore) && productModelPlane.Raycast(rayNow, out float enterNow))
        {
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);
        }

        return Vector3.zero;
    }

    private Vector3 ProductModelPosition (Vector2 screenPos)
    {
        Ray rayNow = Camera.main.ScreenPointToRay(screenPos);
        if (productModelPlane.Raycast(rayNow, out float enterNow))
        {
            return rayNow.GetPoint(enterNow);
        }

        return Vector3.zero;
    }

    public void ToggleProductSizing (Button sourceButton)
    {
        Text buttonLabelText = sourceButton.GetComponentInChildren<Text>();

        if (selectedSizeMode == "custom-size")
        {
            buttonLabelText.text = "AR\nSize";
            selectedSizeMode = "ar-size";
            isReloadProductSizing = true;
            return;
        }

        if (selectedSizeMode == "ar-size")
        {
            buttonLabelText.text = "Real Size";
            selectedSizeMode = "real-size";
            isReloadProductSizing = true;
            return;
        }

        if (selectedSizeMode == "real-size")
        {
            buttonLabelText.text = "AR\nSize";
            selectedSizeMode = "ar-size";
            isReloadProductSizing = true;
            return;
        }

        buttonLabelText.text = "UNKNOWN";
        selectedSizeMode = "unknown";
    }

    private void ResizeProduct ()
    {
        if (selectedSizeMode == "real-size")
        {
          productModel.transform.localScale = new Vector3(10f, 10f, 10f);
          isReloadProductSizing = false;
          return;
        }

        if (selectedSizeMode == "ar-size")
        {
          productModel.transform.localScale = new Vector3(1f, 1f, 1f);
          isReloadProductSizing = false;
          return;
        }

        isReloadProductSizing = false;
    }
}
