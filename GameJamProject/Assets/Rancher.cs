using System.Collections.Generic;
using UnityEngine;
using DialogueUtils;

static class Rancher  {
    public enum State {
        Randomized, // Continue talking randomly
        Sequenced,  // Wait for the user to click so that dialogue can advance
        Exclamation // Has an exclamation mark waiting signal and does not produce any dialogue 
    }
    public static List<string> randomizedDialogues = new List<string>();
    public static State curState = State.Randomized;
    public static int waitClickCounter = 0;
    public static string[,] sequencedDialogue = new string[2,2];
    public static int dialogueNum = -1;
    public static int rateLow = 15;
    public static int rateHigh = 22;
    public static int liveTime = 12;
    /*
    Encapsulation

    string[] Person.RandomizedDialogues {get{return randomizedDialogues;}}
    State Person.CurState {
        get {return curState;}
        set {curState = value;}
    }
    int Person.WaitClickCounter {
        get {return waitClickCounter;}
        set {waitClickCounter = value;}
    }*/

    public static string getRandomizedDialogue() {
        return randomizedDialogues[Random.Range(0, randomizedDialogues.Count)];
    }

    public static string getSequencedDialogue() {
        string s = sequencedDialogue[waitClickCounter, dialogueNum];
        dialogueNum++;
        if (dialogueNum >= sequencedDialogue[0, waitClickCounter].Length) { // Fix to correct length
            dialogueNum = 0;
        }
        return s;
    }

    public static string getDialogue() {
        string s = "";
        switch(curState) {
            case State.Randomized:
                s = getRandomizedDialogue();
                break;
            case State.Sequenced:
                s = getSequencedDialogue();
                break;
            case State.Exclamation:
                break; // Return no dialogue
        }
        return s;
    }

    // Should be called at the start of each week
    public static void setRandomizedDialogues() { //TODO rancher dialogue
        string[] basicDialogue = new string[] {
            ".........I DECLARE THAT TODAY WILL BE A GREAT DAY!",
            "It's time for MOO-RNING song cows!",
            "Oh it's you. Would you like to help out with cow milking?",
            "COWS! Let's have a good milking session today!",
            "Sometimes I like to stand at a mountain peak and echo my voice",
            "Many people know of my cows, but only a few can recall all of their names.",
            "Everyone here is kind. I hope that we can keep living here together.",
            "Let's see where the wind will take me today!"


        };

        string[] joaquinDialogue = new string[] {
            "Hello again Jaiver. Would you like to trade some of your crops for fresh milk?",
            "Javier, it's always nice to see you. I feel like you are our unofficial leader",
            "Let's have a meal together sometime Javier."
        };

        string[] pabloDialogue = new string[] {
            "Pablo, we share so much in common as amazing livestock raisers, right?",
            "You should really speak up sometimes Pablo! I don't hear you talk too much.",
            "If you need a friend Pablo, how about you talk to the study abroad intern?"
        };

        string[] javierDialogue = new string[] {
            "Hello Javier! I apologize but I will pass on your offer today!",
            "Hello again Javier! I might consider purchasing your offerings!",
            "Hello once more Javier! I will strongly consider buying your offerings at this moment!"
        };

        string[] juliaDialogue = new string[] {
            "How are the bees Julia? But please don't bring them near me!",
            "Would you like to walk around sometime Julia? I have a couple errands to run.",
            "Hello there! Sorry, I forgot your name for a moment. Julia, right?"
        };

        string[] slightHintDialogue = new string[] {
            "Unfortunately my cows are running low on water and so am I.",
            "Outsiders may believe that happiness and food are our greatest problems, but I actually think it's water.",
            "Based off my observations, sandbags will be very important in the near future."
        };
        randomizedDialogues.AddRange(basicDialogue);
        randomizedDialogues.AddRange(javierDialogue);
        randomizedDialogues.AddRange(pabloDialogue);
        randomizedDialogues.AddRange(joaquinDialogue);
        randomizedDialogues.AddRange(juliaDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
    }
}