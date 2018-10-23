namespace P09_CardGame.Enums
{
    using Attributes;

    //'\u2660', '\u2663', '\u2666', '\u2665'
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}