using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeCollection : MonoBehaviour {

    ShowCollection page;

    GameObject collection;
    bool mPrev;
    bool mNext;
    int pageNumber;
	void Start () {
        collection = GameObject.Find("Collection");
        page = GetComponent<ShowCollection>();
        pageNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 prevPos = collection.transform.position;
        //if (mPrev)
        //{
        //    collection.transform.position = Vector3.Lerp(prevPos,  (Vector3.right * 5), Time.deltaTime);
        //    mPrev = false;
        //}
        //if (mNext)
        //{
        //    collection.transform.position = Vector3.Lerp(prevPos,  (Vector3.left * 5), Time.deltaTime);
        //   mNext = false;

        //}


    }
    public void Previous()
    {
        //collection.transform.position = Vector3.Lerp(collection.transform.position,collection.transform.position + (Vector3.right*5),Time.deltaTime);
        //mPrev = true;
        //for (int i = 0; i < page.nextPage.Length; i++)
        //{
        //    page.currentPage = page.nextPage;
        //}
        //if (pageNumber >= 0)
        //{
        //    collection.transform.Translate(Vector3.right * 6);
        //    for (int i = 0; i < page.currentPage.Length; i++)
        //    {

        //        page.currentPage[i] = page.previousPage[i];

        //    }
        //    Debug.Log("previous");
        //}

        if (pageNumber > 0)
        {
            pageNumber -= 1;
            page.GetGacha(pageNumber);
        }
        

    }
    public void Next()
    {
        pageNumber += 1;
        //mNext = true;
        //collection.transform.Translate(Vector3.left * 6);

        page.GetGacha(pageNumber);

        //for (int i = 0; i < page.currentPage.Length; i++)
        //{

        //    page.previousPage[i] = page.currentPage[i];

        //}
       
        //for (int i = 0; i < page.currentPage.Length; i++)
        //{
            
        //    page.currentPage[i] = page.nextPage[i];

        //}

        Debug.Log("next");
    }
}
