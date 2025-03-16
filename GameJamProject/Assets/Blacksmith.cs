using System.Collections.Generic;
using UnityEngine;
using DialogueUtils;

static class Blacksmith  {
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
    public static int rateLow = 12;
    public static int rateHigh = 20;
    public static int liveTime = 10;
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
    public static void setRandomizedDialogues() {
        string[] basicDialogue = new string[] {
            "For the best tools near Sierra Mountain, come to me.",
            "Can I interest you in my handmade hammer? It's made of the best materials and with masterful techniques.",
            "I am content just working at my workshop all day.",
            "Have you met all the townsfolk yet? I'm sure that you will find all of us favorable.",
            "I enjoy living in the mountains...it's unfortunate that the climate is getting worse.",
            "Tools are important. They enable humans to become super.",
            "Have you walked around town yet? There are many beautiful details or so I hear.",
            "Do you know what cascading means? For tools, a small chip can easily lead to larger damages.",
            "Thanks for your interest in our town. Your help means a lot to all of us!",
            "This town's children are nice, but I don't interact with them too much.",
            "The waterfall's sounds are nice. I would like to hear it while working.",
            "Did you break any tool? Let me analyze and repair it.",
            "Every day you should work hard and strike while the iron is hot."

        };

        string[] joaquinDialogue = new string[] {
             "Joaquín, it's nice to see you! You're one of my best customers!",
             "We see each other again neighbor! Maybe you're close to making another order?",
             "Do you think the people in this town will be interested in a forging workshop Joaquín?",

        };

        string[] pabloDialogue = new string[] {
            "Pablo, let me know if you ever need one of my tools.",
            "I respect your hard work and talent Pablo.",
            "Pablo, have you talked to the study abroad intern yet?"
        };

        string[] alejandroDialogue = new string[] {
            "Alejandro, can you try quieting the cows? They are distracting me from my work.",
            "Can you refrain from shouting Alejandro? Smithing requires intense concentration.",
            "Hello Pablo, it's been awhile. Have you been tending to the cows since early morning?"
        };

        string[] juliaDialogue = new string[] {
            "Julia, thank you for coming to visit without your bees. Their buzzing noises can be distracting.",
            "Thanks to your bees Julia, the town is a lot livelier."
        };

        string[] slightHintDialogue = new string[] {
            "I heard about a survey where experts said the Sierra Mountain region struggles with crops, but I think others in this community have a different opinion.",
            "Even though I don't know much about climate change, I know it's affecting Monachil and it's getting worse."
        };
        randomizedDialogues.AddRange(basicDialogue);
        randomizedDialogues.AddRange(joaquinDialogue);
        randomizedDialogues.AddRange(pabloDialogue);
        randomizedDialogues.AddRange(alejandroDialogue);
        randomizedDialogues.AddRange(juliaDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
    }
}