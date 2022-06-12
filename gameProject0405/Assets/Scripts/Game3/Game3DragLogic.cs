using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3DragLogic : MonoBehaviour, i_DragAndDropLogic
{
    private Game3Data gameData;
    private Game3UiManager Game3UiManager;
    private Dictionary<string, HashSet<int>> availablePlaces = new Dictionary<string, HashSet<int>>(6);
    private Dictionary<string, Queue<string>> nextFeedback = new Dictionary<string, Queue<string>>(6);

    private int correctAnswers = 0;

    //תמונות במאגר התמונות שאולי ימחקו כשילחצו על עזרה
    public GameObject deletePic1;
    public GameObject deletePic2;


    // Start is called before the first frame update
    void Start()
    {
        gameData = transform.gameObject.GetComponent<Game3Data>();

        availablePlaces.Add("product", new HashSet<int>() { 1, 2, 3, 4, 5 });
        availablePlaces.Add("friend", new HashSet<int>() { 0, 1, 2, 3, 4, 5 });
        availablePlaces.Add("animal", new HashSet<int>() { 0, 1, 2, 3, 4, 5 });
        availablePlaces.Add("sunglasses", new HashSet<int>() { 3, 4, 5 });
        availablePlaces.Add("nature", new HashSet<int>() { 1, 2, 3, 4, 5 });
        availablePlaces.Add("food", new HashSet<int>() { 0, 1, 2, 3, 4, 5 });

        Queue<string> productAndFriendQueue = new Queue<string>();
        productAndFriendQueue.Enqueue("אתם בצעד הראשון להבין את החוקיות");
        productAndFriendQueue.Enqueue("!אלופים הצלחתם להבין את החוקיות תמונה של מוצר לפני ציטוט הכרחית ליצירת פיד מנצח");
        Queue<string> foodAndNatureQueue = new Queue<string>();
        foodAndNatureQueue.Enqueue("אתם בצעד הראשון להבין את החוקיות");
        foodAndNatureQueue.Enqueue("!אלופים הצלחתם להבין את החוקיות תמונה של טבע אחרי אוכל הכרחית ליצירת פיד מנצח");
        Queue<string> animalQueue = new Queue<string>();
        animalQueue.Enqueue("!אלופים הצלחתם להבין את החוקיות תמונה עם חיית מחמד הכרחית ליצירת פיד מנצח");
        Queue<string> sunglassesQueue = new Queue<string>();
        sunglassesQueue.Enqueue("!אלופים הצלחתם להבין את החוקיות תמונה עם משקפי שמש חייבת להיות בפיד העליון כדי ליצור פיד מנצח");

        nextFeedback.Add("product", productAndFriendQueue);
        nextFeedback.Add("friend", productAndFriendQueue);
        nextFeedback.Add("food", foodAndNatureQueue);
        nextFeedback.Add("nature", foodAndNatureQueue);
        nextFeedback.Add("animal", animalQueue);
        nextFeedback.Add("sunglasses", sunglassesQueue);
    }

    public void validateOnRelese(Dragable dragable, DropArea dropArea)
    {
        if (isTrueAnswer(dragable, dropArea))
        {
            int indexOfDropArea = gameData.getIndexOfDropArea(dropArea);

            dragable.gameObject.SetActive(false);
            gameData.getCurrentInfluencer().setImage(dragable.getImage(), indexOfDropArea);
            dropArea.canDrop = false;
            gameData.uiManager.updateDropAreasImages();
        }
    }

    private bool isTrueAnswer(Dragable dragable, DropArea dropArea)
    {
        bool answer = false;
        bool partWrong = false;

        string type = getTypeOfDragable(dragable);
        int indexOfDropArea = gameData.getIndexOfDropArea(dropArea);

        if (availablePlaces.ContainsKey(type))
        {
            Dictionary<string, HashSet<int>> needToDelete = createToDeleteDict(indexOfDropArea, type);
            needToDelete.Remove(type);

            bool isValidPlace = availablePlaces[type].Contains(indexOfDropArea);
            if (isValidPlace && isAbleToDelete(needToDelete))
            {
                deleteFromAvailablePlaces(needToDelete);
                answer = true;
                availablePlaces.Remove(type);
                correctAnswers++;
            } 
            else if(!isValidPlace){
                Debug.Log("partly worng: this dropArea is not in available list of '" + type + "'");

            }
            partWrong = true;
        }

        triggerFeedback(answer, partWrong, type, dragable);
        checkIfGameEnded();

        return answer;
    }

    private void checkIfGameEnded()
    {

        if(correctAnswers == 6)
        {
            StartCoroutine(gameData.uiManager.displayFinishGame(3,1));
        }
    }

    private void triggerFeedback(bool answer, bool partWrong, string type, Dragable dragable)
    {
            // בדיקה לפידבק
            if (answer)
            {
                string myfeedback = nextFeedback[type].Dequeue();
                gameData.uiManager.showFeedback(myfeedback);
            }
            else if (partWrong)
            {
                dragable.returnToInitPosition();
                gameData.uiManager.showFeedback("נסו לחשוב על מיקום בהתאם לחוקיות!");
                // פידבק נכון חלקי
            }
            else
            {
                dragable.returnToInitPosition();
                gameData.uiManager.showFeedback("בטוחים שהתמונה הזו רלוונטית ליצירת פיד מנצח?");
                // פידבק לא נכון
            }
    }

    private Dictionary<string, HashSet<int>> createToDeleteDict(int index, string type)
    {
        Dictionary<string, HashSet<int>> needToDelete = new Dictionary<string, HashSet<int>>(6);

        foreach(string key in availablePlaces.Keys)
        {
            needToDelete.Add(key, new HashSet<int> { index });
        }

        switch (type)
        {
            case "friend":
                if (needToDelete.ContainsKey("product"))
                {
                    addNumbersToIndex(index, needToDelete["product"]);
                }
                break;

            case "product":
                if (needToDelete.ContainsKey("friend"))
                {
                    addNumbersFromIndex(index, needToDelete["friend"]);
                }
                break;

            case "food":
                if (needToDelete.ContainsKey("nature"))
                {
                    addNumbersToIndex(index, needToDelete["nature"]);
                }
                    
                break;

            case "nature":
                if (needToDelete.ContainsKey("food"))
                {
                    addNumbersFromIndex(index, needToDelete["food"]);
                }
                break;
        }

        return needToDelete;
    }

    private void addNumbersFromIndex(int index, HashSet<int> list)
    {
        for (int i = index; i < 6; i++)
        {
            list.Add(i);
        }
    }

    private void addNumbersToIndex(int index, HashSet<int> list)
    {
        for (int i = 0; i < index; i++)
        {
            list.Add(i);
        }
    }

    private void deleteFromAvailablePlaces(Dictionary<string, HashSet<int>> toDelete)
    {
        foreach (string key in toDelete.Keys)
        {
            int removes = availablePlaces[key].RemoveWhere(p => toDelete[key].Contains(p));
            //Debug.Log("removed " + removes + " from " + key);
        }
    }

    private bool isAbleToDelete(Dictionary<string, HashSet<int>> toDelete)
    {
        HashSet<int> uniqePlacesForImages = new HashSet<int>();
        foreach (string key in toDelete.Keys)
        {
            HashSet<int> tmpSet = new HashSet<int>(availablePlaces[key]);
            tmpSet.RemoveWhere(p => toDelete[key].Contains(p));

            if (tmpSet.Count == 0)
            {
                Debug.Log("Faild to validate delete: '" + key + "' will remain witout places");
                return false;
            }
            else if(tmpSet.Count == 1)
            {
                if (uniqePlacesForImages.Overlaps(tmpSet))
                {
                    Debug.Log("Faild to validate delete: '" + key + "' will remain witout places");
                    return false;
                } else
                {
                    uniqePlacesForImages.UnionWith(tmpSet);
                }
            }
        }
        return true;
    }

    private string getTypeOfDragable(Dragable dragable)
    {
        return dragable.getImage().name;
    }

}

