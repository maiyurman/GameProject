using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Chat : MonoBehaviour
{
    public GameObject content;
    public TextMeshProUGUI titleTxt;
    public Image largeProfilePhoto;
    public ScrollRect scrollRect;

    public GameObject messageContainer;
    public GameObject videoTemplate;
    public GameObject photoTemplate;
    public GameObject textMessageTemplate;
    public GameObject objectTemplate;

    private float initialContentHeight;
    private float currentHeight = 0;
    private bool isInit = false;
    private string profilePhoto = "chatUser";

    //public GameObject testObject;

    public void initChat()
    {
        if (!isInit)
        {
            initialContentHeight = getHeight(content);
            Debug.Log("Chat initialContentHeight: " + initialContentHeight);
            isInit = true;
        }
    }

    public void setChatTitle(string title)
    {
        if (!isInit)
        {
            initChat();
        }
        titleTxt.text = title;
    }

    public void setProfilePhoto(string profilPhoto)
    {
        this.profilePhoto = profilPhoto;

        // set large profile photo
        largeProfilePhoto.sprite = Resources.Load<Sprite>("Chat/Images/" + profilePhoto);

    }

    //public void B1()
    //{
    //    addObject(Direction.RECEIVE, testObject);
    //    //addVideo(Direction.RECEIVE, "6", playVideo2);
    //    addPhoto(Direction.RECEIVE, "6");
    //    //addTextMessage(Direction.RECEIVE, "sdfsdfs\ndsfsfsfs");
    //    //addTextMessage(Direction.RECEIVE, "???? ??? ??? ??? ???????? ??????? ?????? ??? ??? ??? '??????????? ???????9", 3);
    //}

    //public void B2()
    //{
    //    //addVideo(Direction.SEND, "2", playVideo3);
    //    addPhoto(Direction.SEND, "2");
    //    //addTextMessage(Direction.SEND, "???? ??? ??? ??? ???????? ??????? ?????? ??? ??? ??? '??????????? ???????9", 3);
    //}

    //public void playVideo2()
    //{
    //    Debug.Log("play video 2");
    //}

    //public void playVideo3()
    //{
    //    Debug.Log("play video 3");
    //}

    public void addVideo(Direction direction, string imageName, UnityAction action)
    {
        GameObject video = Instantiate(videoTemplate, new Vector3(0, 0, 0), Quaternion.identity);
        video.GetComponent<Image>().sprite = Resources.Load<Sprite>("Chat/Images/" + imageName);
        
        // set button function
        video.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(action);

        addMessageItem(direction, video.transform);
    }

    public void addObject(Direction direction, GameObject requestedObject)
    {
        GameObject objTemplate = Instantiate(objectTemplate, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject newObject = Instantiate(requestedObject, new Vector3(0, 0, 0), Quaternion.identity);
        newObject.transform.SetParent(objTemplate.transform, false);
        newObject.transform.localScale = new Vector3(1, 1, 1);
        float width = getWidth(objTemplate);
        float height = getHeight(objTemplate);
        setSize(newObject, width * 0.75f, height * 0.75f);

        addMessageItem(direction, objTemplate.transform);
    }

    public void addPhoto(Direction direction, string imageName)
    {
        GameObject photo = Instantiate(photoTemplate, new Vector3(0, 0, 0), Quaternion.identity);
        photo.GetComponent<Image>().sprite = Resources.Load<Sprite>("Chat/Images/" + imageName);

        addMessageItem(direction, photo.transform);
    }

    public void addTextMessage(Direction direction, string message, int numOfLines)
    {
        GameObject textMessage = Instantiate(textMessageTemplate, new Vector3(0, 0, 0), Quaternion.identity);
        TextMeshProUGUI textMesh = textMessage.GetComponent<TextMeshProUGUI>();
        textMesh.text = message;

        float requestedHeight = (textMesh.fontSize + textMesh.lineSpacing/4) * numOfLines;
        textMesh.GetComponent<RectTransform>().sizeDelta = new Vector2(textMesh.GetComponent<RectTransform>().rect.width, requestedHeight);

        addMessageItem(direction, textMessage.transform);
    }

    public void addTextMessage(Direction direction, string message)
    {
        addTextMessage(direction, message, 2);
    }

    private void addMessageItem(Direction direction, Transform messageContent)
    {
        bool isSend = false;
        if (direction == Direction.SEND)
        {
            isSend = true;
        }
        GameObject itemToAdd = createBaseMessageContainer(isSend, messageContent);

        currentHeight += getHeight(itemToAdd) + 15 * 2;
        setHeight(content, currentHeight);
        scrollToBottom();
    }

    private GameObject createBaseMessageContainer(bool isSend, Transform messageContent)
    {
        GameObject g = Instantiate(messageContainer, new Vector3(0, 0, 0), Quaternion.identity);
        g.transform.SetParent(content.transform, false);
        g.transform.localScale = new Vector3(1, 1, 1);
        Transform container = g.transform.GetChild(0);
        float requesterHeight = messageContent.GetComponent<RectTransform>().rect.height;
        float totalWidth = g.GetComponent<RectTransform>().rect.width;
        g.GetComponent<RectTransform>().sizeDelta = new Vector2(totalWidth, requesterHeight);

        // set profile photo
        container.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Chat/Images/" + profilePhoto);

        RectTransform containerRectTransform = container.GetComponent<RectTransform>();
        if (isSend)
        {
            GameObject.Destroy(container.GetChild(0).gameObject); // remove icon

            float left = totalWidth;
            left -= messageContent.GetComponent<RectTransform>().rect.width;
            left -= 20;

            containerRectTransform.offsetMin = new Vector2(left, 0);
        } else
        {
            float right = totalWidth;
            right -= container.GetChild(0).GetComponent<RectTransform>().rect.width;
            right -= messageContent.GetComponent<RectTransform>().rect.width;
            right -= 20;
            containerRectTransform.offsetMax = new Vector2(-right, 0);
        }

        messageContent.SetParent(container); // add messageContent
        messageContent.gameObject.SetActive(true);
        messageContent.localScale = new Vector3(1, 1, 1);
        g.SetActive(true);
        return g;
    }

    public void clearChat()
    {
        foreach (Transform child in content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        currentHeight = 0;
        setHeight(content, initialContentHeight);
    }

    private float getHeight(GameObject obj)
    {
        return obj.GetComponent<RectTransform>().rect.height;
    }

    private float getWidth(GameObject obj)
    {
        return obj.GetComponent<RectTransform>().rect.width;
    }

    private void setHeight(GameObject obj, float height)
    {
        setSize(obj, obj.GetComponent<RectTransform>().rect.width, height);
    }

    private void setWidth(GameObject obj, float width)
    {
        setSize(obj, width, obj.GetComponent<RectTransform>().rect.height);
    }

    private void setSize(GameObject obj, float width, float height)
    {
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    private void scrollToBottom()
    {
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }

    public enum Direction
    {
        SEND, RECEIVE
    }
}
