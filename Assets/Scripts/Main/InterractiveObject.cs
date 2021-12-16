using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterractiveObject : MonoBehaviour
{
    public string typeObject = null;
    public int id;
    [SerializeField]
    private bool active = true;

    public Vector3 initalPos;
    public Quaternion initalRot;


    public void collect()
    {
        if(typeObject == "Taquin")
        {
            active = false;
            PlayerPrefs.SetInt("Taquin", 1);
            SceneManager.LoadScene(1);
        }else if(typeObject == "Maze")
        {
            Debug.Log("Here");
            active = false;
            PlayerPrefs.SetInt("Maze", 1);
            SceneManager.LoadScene(2);
        }
        else if (typeObject == "Collectible")
        {
            this.transform.Translate(0, -100, 0);
        }
    }

    public bool collectReturn(InterractiveObject item)
    {
        if (typeObject == "Pillar" && id == item.id)
        {
            if (id == 1)
            {
                item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y-1f, this.transform.position.z);
            }
            else if (id == 2)
            {
                item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.75f, this.transform.position.z);
            }
            else if (id == 3)
            {
                item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
                item.transform.rotation = new Quaternion(-90, 0, 0, 0);
            }
            else if (id == 4)
            {
                item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
            }else if(id == 5)
            {
                item.transform.position = new Vector3(44.3f, -0.8f, 48.1f);
            }
            else if (id == 6)
            { 
                item.transform.position = new Vector3(55.3f, -0.8f, 48.1f); 
            }
            inactive();
            item.inactive();
            return true;
        }
        return false;
    }

    public bool getState()
    {
        return active;
    }

    public void inactive()
    {
        active = false;
    }

    public void activate()
    {
        active = true;
    }

    private void Update()
    {
        if (typeObject == "Collectible")
        {
            if (id == 4 || id==2 || id == 5 || id == 6)
            {
                this.transform.Rotate(Vector3.back * 30 * Time.deltaTime);
            }
            else
            {
                this.transform.Rotate(Vector3.up * 30 * Time.deltaTime);
            }
            
        }
        
    }

}
