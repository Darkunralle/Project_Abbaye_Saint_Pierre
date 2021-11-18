using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int[,] matrice = new int[6,6] {
        {99,99,99,99,99,99},
        {99,0 ,0 ,0 ,0 ,99}, 
        {99,0 ,0 ,0 ,0 ,99}, 
        {99,0 ,0 ,0 ,0 ,99}, 
        {99,0 ,0 ,0 ,1 ,99}, 
        {99,99,99,99,99,99}};
    /*
    public int[,] vicotryMatrice = new int[6, 6] {
        {99,99,99,99,99,99},
        {99,0 ,15,14,13,99},
        {99,12,11,10,9 ,99},
        {99,8 ,7 ,6 ,5 ,99},
        {99,4 ,3 ,2 ,1 ,99},
        {99,99,99,99,99,99}};*/

    //
    //  5,-5 / 4,-5 / 3,-5 / 2,-5 / 1,-5 / 0,-5
    //  5,-4 / 4,-4 / 3,-4 / 2,-4 / 1,-4 / 0,-4
    //  5,-3 / 4,-3 / 3,-3 / 2,-3 / 1,-3 / 0,-3
    //  5,-2 / 4,-2 / 3,-2 / 2,-2 / 1,-2 / 0,-2
    //  5,-1 / 4,-1 / 3,-1 / 2,-1 / 1,-1 / 0,-1
    //  5,-0 / 4,-0 / 3,-0 / 2,-0 / 1,-0 / 0,-0

    public List<bool> check(int id, List<bool> checklist)
    {
        int _column = 5;
        int _ligne = -5;
        for(int c = 0; c < 6; c++)
        {
            for (int l = 0; l < 6; l++)
            {
                //Debug.Log(matrice[c, l]);
                if(matrice[c,l] == id)
                {
                    _column -= c;
                    _ligne += l;

                    if (matrice[_column, _ligne - 1] == 0)
                    {
                        checklist[1] = true;
                    }
                    if (matrice[_column - 1, _ligne] == 0)
                    {
                        checklist[2] = true;
                    }
                    if (matrice[_column, _ligne + 1] == 0)
                    {
                        checklist[3] = true;
                    }
                    if (matrice[_column + 1, _ligne] == 0)
                    {
                        checklist[4] = true;
                    }

                    return checklist;
                }
            }
        }
        return checklist;
    }
}
