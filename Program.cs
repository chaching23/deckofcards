using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            // newDeck.reset();
            newDeck.shuffle();
            // newDeck.deal();
            // newDeck.deal();
            
            Player alex = new Player("Alexander");
            // alex.draw(newDeck.deal());
            alex.draw(newDeck);
            alex.draw(newDeck);
            alex.draw(newDeck);
            
            alex.discard(2);
        }
    }

    class Card
    {
        public String stringVal;
        public String suit;
        public int val;

        public Card(String stringVal, String suit, int val){
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }
    }

    class Deck
    {
        public List<Card> cards { get; set; }

        public Deck(){
            reset();
        }

        public Card deal(){ 
            System.Console.WriteLine(cards.Count);
            Card dealt_card = cards[cards.Count-1];
            cards.Remove(dealt_card);
            System.Console.WriteLine("Dealt a " + dealt_card.stringVal + " of " + dealt_card.suit);
            return dealt_card;
        }

        public void reset()
        {
            cards = new List<Card>();

            string[] suits = {"clubs", "diamonds", "hearts", "spades"};
            string[] strVals = {"Ace","two","three","four","five","six","seven","eight","nine","ten","Jack","Queen","King"};
            
            //For each suit
            foreach(string suit in suits)
            {
                //For each card in each suite
                for(int i = 0; i < strVals.Length; i++){
                    Card newCard = new Card(strVals[i], suit, i+1);
                    cards.Add(newCard);
                }
            }
            
            //Printing out all cards
            foreach(var card in cards){
                System.Console.WriteLine(card.stringVal + " of " + card.suit);
            }
        }

        public void shuffle(){
            Random rand = new Random();
            
            for(int i = cards.Count; i > 0; i--){
                int rand_num = rand.Next(0, cards.Count);
                
                cards.Add(cards[rand_num]);
                cards.Remove(cards[rand_num]);
            }

            foreach(var card in cards){
                System.Console.WriteLine(card.stringVal + " of " + card.suit);
            }
        }
    }

    class Player
    {
        public String name;
        public List<Card> hand;

        public Player(String name){
            this.name = name;
            this.hand = new List<Card>();
        }

        public Card draw(Deck deck){
            Card card = deck.deal();
            hand.Add(card);
            System.Console.WriteLine("Player drew: " + card.stringVal + " of " + card.suit);
            return card;
        }

        public Card discard(int i){
            if(i >= 0 && i < hand.Count){
                Card remove_card = hand[i];
                hand.RemoveAt(i);
                System.Console.WriteLine("Removed card: " + remove_card.stringVal + " of " + remove_card.suit);
                return remove_card;
            } else {
                System.Console.WriteLine("Returning null");
                return null;
            }
        }
    }
}