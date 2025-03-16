using System.Collections.Generic;
using UnityEngine;
using DialogueUtils;

static class Shepherd  {
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
    public static int rateLow = 16;
    public static int rateHigh = 22;
    public static int liveTime = 15;
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
    public static void setRandomizedDialogues() { //TODO Shepherd dialogue
        string[] basicDialogue = new string[] {
            ".............................Oh, were you here the whole time?",
            "Would you like to look at the sheep? They are kind.",
            "I like the sheep because they are nice to me.",
            "I don't think so.",
            "I'd agree with that.",
            "Maybe.",
            "Sheep are wonderful creatures, right?",
            "Sometimes, I don't know what to say.",
            "Did you see it? A lamb was just born!",
            "I'm a shepherd because I like being around sheep.",
            "In my family, I'm the only shepherd."
        };

        string[] javierDialogue = new string[] {
            "Your blacksmithing expertise impresses me Javier. You should teach a workshop sometime.",
            "Hello Javier, I don't need anything at the moment.",
            "Greetings Javier, I will likely contact you soon for an order."
        };

        string[] joaquinDialogue = new string[] {
            "Joaquín, your crops are really tasty but I guess my sheep don't like it."
        };

        string[] alejandroDialogue = new string[] {
            "Alejandro, has anyone ever told you to lower your volume a little?",
            "Hello Javier, we meet again. Even though you're a little loud, it's always nice to see you."
        };

        string[] juliaDialogue = new string[] {
            "Hello Julia, are you strolling around town again?",
            "Julia, we meet again. This has happened a couple times right?"
        };

        string[] slightHintDialogue = new string[] {
            "Hello Joaquín, have you noticed the water scarcity in recent times? I think we should be prepared.",
            "My food supply looks a little low, but I should also make sure that I conserve water."
        };
        randomizedDialogues.AddRange(basicDialogue);
        randomizedDialogues.AddRange(javierDialogue);
        randomizedDialogues.AddRange(pabloDialogue);
        randomizedDialogues.AddRange(alejandroDialogue);
        randomizedDialogues.AddRange(juliaDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
    }
}