using UnityEngine;

namespace DialogueUtils {
    public enum State {
        Randomized, // Continue talking randomly
        Sequenced,  // Wait for the user to click so that dialogue can advance
        Exclamation // Has an exclamation mark waiting signal and does not produce any dialogue 
    }
    interface Person {
        string[] RandomizedDialogues{get;}
        State CurState {get;set;}
        int WaitClickCounter {get; set;}
    }
}