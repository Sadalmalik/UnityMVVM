using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sadalmalik.ExampleMVVM
{
    [Serializable]
    public class Card
    {
        public string firstName;
        public string secondName;
        public int age;
    }
    
    [Serializable]
    public class CardsModel
    {
        public Card currentCard = new Card();
        
        public List<Card> cards = new List<Card>();
        
        public event Action CardSaved;
        
        public void SaveCurrentCard()
        {
            Debug.Log("SaveCurrentCard call");
        
            CardSaved?.Invoke();
        }
    }
}