using System.Collections.Generic;
using UnityEngine;
using DialogueUtils;

static class Beekeeper  {
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
    public static int rateLow = 8;
    public static int rateHigh = 12;
    public static int liveTime = 6;
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
    public static void setRandomizedDialogues() { //TODO Beekeeper dialogue
        string[] basicDialogue = new string[] {
            "Today seems to be a peaceful day. Do you want to relax with me and the bees?",
            "Spring is my favorite season because the bees help produce such wonderful flowers!",
            "Did you know that honey is one of the few foods that never expire?",
            "You asked if I prefer bees or people? Honestly...wait one moment, my bees need me.",
            "So far, this season has been much worse than previous years.",
            "Do you know about the butterfly effect? If one drop of water falls into a lake will anyone notice? I personally think someone will notice.",
            "My son has gotten sick. I think he ate some bad meat.",
            "My son ate some bad meat the shepherd, the sheep might've been sick.",
            "I think the water scarcity from the mountains make wild animals keep coming here to eat our crops and drink our water, and end up infecting the livestock."

        };

        string[] javierDialogue = new string[] {
            "Hello Javier. I hope you are doing well and I do apologize if my bees have been causing trouble.",
            "Javier, I would like to place a request for a custom water can."
        };

        string[] pabloDialogue = new string[] {
            "Hello Pablo! Would you like to accompany me sometime? I always appreciate your presenece.",
            "Pablo, have you talked to the study abroad intern? This intern is a great person and very enthusiastic!"
        };

        string[] alejandroDialogue = new string[] {
            "Can you keep the volume down a little Alejandro? I am trying to enjoy my quiet time in nature.",
            "Yes, once again Alejandro, my name is Julia."
        };

        string[] joaquinDialogue = new string[] {
            "Joaquín, may I bring my bees with me next time? I think they will do wonders for your crops.",
            "Are you helping to host another event Joaquín? I would love to help!"
        };

        string[] slightHintDialogue = new string[] {
            "This too shall pass. I love this quote but maybe we can change something? I fear that this region is close to being devastated.",
            "I've noticed recently that as a community, we are running low on freshwater. For this region, even a large surplus may not be enough.",
            "My son has gotten sick. I think he ate some bad meat.",
            "My son ate some bad meat the shepherd, the sheep might've been sick.",
            "I think the water scarcity from the mountains make wild animals keep coming here to eat our crops and drink our water, and end up infecting the livestock."

        };
        randomizedDialogues.AddRange(basicDialogue);
        randomizedDialogues.AddRange(javierDialogue);
        randomizedDialogues.AddRange(pabloDialogue);
        randomizedDialogues.AddRange(alejandroDialogue);
        randomizedDialogues.AddRange(joaquinDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
    }
}