using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject uiVictory;
    public GameObject startScreen;

    int column = 0;
    int ligne = 0;

    // Matrice du jeu
    // 99 -> mur // 0 -> vide
    public int[,] matrice = new int[6,6] {
        {99,99,99,99,99,99},
        {99,6 ,0 ,4 ,0 ,99},
        {99,5 ,7 ,0 ,13,99},
        {99,9 ,8 ,3 ,12,99},
        {99,10,2 ,1 ,11,99},
        {99,99,99,99,99,99}};

    // Matrice de condition de victoire
    public int[,] victoryMatrice = new int[6, 6] {
        {99,99,99,99,99,99},
        {99,1 ,2 ,3 ,4 ,99},
        {99,5 ,6 ,7 ,8 ,99},
        {99,9 ,10,11,12,99},
        {99,13,0 ,0 ,0 ,99},
        {99,99,99,99,99,99}};

    private void Start()
    {
        uiVictory.SetActive(false);
    }

    // Vérifie si il y a quelque chose dans les 4 direction autour si non retourne "True" dans cette direction
    public List<bool> check(int id,List<bool> checklist)
    {
        // Parcourt de la matrice
        for(int c = 0; c < 6; c++)
        {
            for (int l = 0; l < 6; l++)
            {
                if(matrice[c,l] == id)
                {
                    // Sauvegarde de l'emplacement pour mettre a jour la matrice
                    column = c;
                    ligne = l;
                    // Up
                    if (matrice[c - 1, l] == 0)
                    {
                        checklist[0] = true;
                    }
                    // Right
                    if (matrice[c, l + 1] == 0)
                    {
                        checklist[1] = true;
                    }
                    //Down
                    if (matrice[c + 1, l] == 0)
                    {
                        checklist[2] = true;
                    }

                    if (matrice[c, l - 1] == 0)
                    {
                        checklist[3] = true;
                    }
                    return checklist;
                }
            }
        }
        Debug.Log("Na");
        return checklist;
    }

    // Déplace les éléments dans la matrice 
    // Demande la direction dans laquel a était déplacer l'objet et interchange les éléments en fonction
    public void matriceUpdate(string _direc, int _id)
    {
        matrice[column, ligne] = 0;
        if (_direc == "up")
        {
            matrice[column - 1, ligne] = _id;
        }
        else if(_direc == "right")
        {
            matrice[column, ligne + 1] = _id;
        }
        else if(_direc == "down")
        {
            matrice[column + 1, ligne] = _id;
        }
        else if(_direc == "left")
        {
            matrice[column, ligne - 1] = _id;
        }

        // Reset la sauvegarde des emplacements
        column = 0;
        ligne = 0;

        if (victory())
        {
            Debug.Log("Win");
            uiVictory.SetActive(true);
        }
    }

    // Affiche la matrice
    public void printMat()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(matrice[i, 0] +" / " + matrice[i, 1] + " / " + matrice[i, 2] + " / " + matrice[i, 3] + " / " + matrice[i, 4] + " / " + matrice[i, 5]);
        }

    }

    // Compare les deux matrices pour savoir si l'on a gagner
    public bool victory()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int a = 0; a < 6; a++)
            {
                if(matrice[i,a] != victoryMatrice[i,a])
                {
                    return false;
                }
            }

        }
        return true;
    }

    public void loadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void startGame()
    {
        startScreen.SetActive(false);
    }
}


