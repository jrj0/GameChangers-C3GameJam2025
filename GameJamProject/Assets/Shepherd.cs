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
            "Do you know Sam? I heard something not human used to live here...",
            "Every morning I want to shout, 'Joaquín is ready for another day!'", 
            "The weather seems to be getting worse...",
            "I am very worried about my crops these days!",
            "Did you know? My father was also a farmer!",
            "Have you heard? My grandfather was a farmer!",
            "Has anyone told you? My great-grandfather was a farmer!",
            "Can you believe it? My family have been farmers for as long as I can remember!",
            "I'll let you in on a secret...I started farming when I was just 5 years old!",
            "My children want to be farmers too. Unfortunately, the climate is changing...",
            "Is your study abroad going well? We don't get visitors often.",
            "Thank you for your interest and passion in helping our humble town!",
            "You should stop by my home for dinner sometime soon.",
            "Have you eaten yet? Are you staying well?",
            "An early morning to a late night outdoors is the best!",
            "Are you getting enough outdoor time? If not, farm with me!",
            "I don't know much about life outside of the Sierra Nevada, but I enjoy it here!",
            "I'm glad that I learned English in my spare time, so that I could talk with you!",
            "The early bird gets the worm!",
            "The night owl is late to the harvest!",
            "What's your favorite food? Let's have it together for dinner tonight!",
            "My least favorite season? It's definitely winter.",

        };

        string[] javierDialogue = new string[] {
            "Have you seen Javier yet? He creates the best tools in this area!",
            "Hey Javier, how are you doing today? I might need to upgrade my tools soon.",
            "Javier! Just the person I wanted to see, I think I want a new tiller.",
            "I haven't seen you in a couple days Javier. Make sure to go outside once in a while!",
            "The annual festival is quickly approaching. Would you like to help Javier?"
        };

        string[] pabloDialogue = new string[] {
            "Have you met the Pablo the shepherd yet? His sheep usually prefer grazing wild plants...",
            "Pablo, you've been doing great these days! Your sheep look very happy!",
            "How are you doing on this fine day Pablo?",
            "Pablo! It's almost time for the annual festival. Would you like to help?"
        };

        string[] alejandroDialogue = new string[] {
            "Have you talked to Alejandro the rancher yet? His cows love my crops!",
            "Good day to you Alejandro! My children always enjoy your cows' fresh milk!",
            "Hello Alejandro, would you like to help host the annual festival this year?"
        };

        string[] juliaDialogue = new string[] {
            "Have you spoken with Julia yet? Her bees help my crops from time to time!",
            "Good day to you Julia! It's been awhile since I have seen you!",
            "Would you like to come over sometime Julia? Make sure to bring your bees too!",
            "Would you like to help with the festival this year Julia? Everyone always enjoys the presence of you and your bees!"
        };

        string[] slightHintDialogue = new string[] {
            "I would like fertilizer, but it's not good for our community right now.",
            "Although I need water for my crops, the land tells me that we should invest more into having a surplus of water.",
            "Come talk to me if you need help with anything! I know a lot about farming!",
            "Life here is so nice! But the climate has changed so much recently, hopefully things get better!",
            "I am a farmer so I love crops and we never run out of food! Our freshwater reserves seem to never be enough, though.",
            "Everyone here really wants to protect our land, so make sure to give them a listen!",
            "I heard a survey about our region was conducted recently! Expert researchers too, but I think our responses were more considerate."
        };
        randomizedDialogues.AddRange(basicDialogue);
        randomizedDialogues.AddRange(javierDialogue);
        randomizedDialogues.AddRange(pabloDialogue);
        randomizedDialogues.AddRange(alejandroDialogue);
        randomizedDialogues.AddRange(juliaDialogue);
        randomizedDialogues.AddRange(slightHintDialogue);
    }
}