using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface i_DragAndDropLogic{
    public void validateOnRelese(Dragable dragable, DropArea dropArea);
}

public class DragAndDropManager : MonoBehaviour
{
    private i_DragAndDropLogic dragAndDropLogic;
    public  Vector3 offset;
    private GameObject selectedObject;
    private Dragable dragableOfObject;
    private DropArea dropAreaOfObject;
    private Collider2D selectedColider;
    private bool isInDragNow;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        initDragAndDropObjects();
        dragAndDropLogic = GetComponent<i_DragAndDropLogic>();
        //Debug.Log(dragAndDropLogic);
    }

    // Update is called once per frame
    void Update()
    {
        //הנקודה שמייצגת את המיקום של העכבר
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startDragOnClick();
        updatePositionDuringDrag();
        stopDragOnRelese();
    }

    private void startDragOnClick()
    {
        // clicked on object during mouse movement
        if (Input.GetMouseButtonDown(0) && isInDragNow == false)
        {
            if (isClickedOnDragableObject() == true)
            {
                isInDragNow = true;
                selectedColider.enabled = false;
                offset = selectedObject.transform.position - mousePosition;
            }
            else
            {
                selectedObject = null;
                dragableOfObject = null;
            }
        }
    }

    private bool isClickedOnDragableObject()
    {
        bool result = false;

        selectedColider = Physics2D.OverlapPoint(mousePosition);
        if (selectedColider)
        {
            selectedObject = selectedColider.transform.gameObject;
            dragableOfObject = selectedObject.GetComponent<Dragable>();
            if (dragableOfObject && dragableOfObject.canDrag)
            {
                result = true;
            }
        }

        return result;
    }

    private void updatePositionDuringDrag()
    {
        if (selectedObject != null)
        {
            if (dragableOfObject && dragableOfObject.canDrag)
            {
                selectedObject.transform.position = mousePosition + offset;
            }
        }
    }

    private void stopDragOnRelese()
    {
        if (Input.GetMouseButtonUp(0) && isInDragNow)
        {
            if (isRelesedOnDropAreaObject() == true)
            {
                // send to logic the dropArea and dragableOfObject
                dragAndDropLogic.validateOnRelese(dragableOfObject, dropAreaOfObject);
            }
            else
            {
                dragableOfObject.returnToInitPosition();
            }
            selectedColider.enabled = true;
            initDragAndDropObjects();
        }
    }

    private bool isRelesedOnDropAreaObject()
    {
        bool result = false;

        Collider2D dropAreaColider = Physics2D.OverlapPoint(mousePosition);
        if (dropAreaColider)
        {
            GameObject dropAreaGameObject = dropAreaColider.transform.gameObject;
            dropAreaOfObject = dropAreaGameObject.GetComponent<DropArea>();
            if (dropAreaOfObject && dropAreaOfObject.canDrop)
            {
                result = true;
            }
        }

        return result;
    }

    private void initDragAndDropObjects()
    {
        selectedColider = null;
        selectedObject = null;
        dragableOfObject = null;
        dropAreaOfObject = null;
        isInDragNow = false;
    }
}