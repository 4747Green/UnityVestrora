using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CombatRoundHandler 
{

    private int turnCounter = 0;
    private int turnCounterForUI;
    private int numberOfCharactersInCombat;
    private int round = 1;
    private int lastRound =1;
    public CombatRoundHandler(int numberOfCharactersInCombat){
        this.numberOfCharactersInCombat = numberOfCharactersInCombat;
        this.round = 1;
        this.lastRound =1;
        CorrectTurnCounterForUI();
    }

    public int GetTurnNumberToBackLogBy (int numberOfTurnsToQueueFor){
        double num = numberOfTurnsToQueueFor/2;

       return numberOfCharactersInCombat * ((int)Math.Round(num));
    }

    private void NextRound(){
        round++;
    }
    private void ResetTurnCounter(){
        turnCounter = 0;
    }

    private void NextTurn(){
        turnCounter++;
    }

    public void ProcessTurn(){
        if (CheckIfNewRound())
        {
            NextRound();
            ResetTurnCounter();
        }else{
            NextTurn();
        }
        CorrectTurnCounterForUI();
    }
    private void CorrectTurnCounterForUI(){
        turnCounterForUI = turnCounter +1;
    }
    private bool CheckIfNewRound()
    {
        
        return (turnCounter >= (numberOfCharactersInCombat));
    }

    public bool NewRound(){
        if(lastRound == round){
            return false;
        }else{
            lastRound = round;
            return true;
        }
    }

    public int GetTurnCounterForUI(){
        return turnCounterForUI;
    }
    public int GetTurnCounter(){
        return turnCounter;
    }
    public int GetRound(){
        return round;
    }

}

