namespace BurrowsWheelerTransform
{
    public class BIndex
    {
        public BIndex(char symbol, int index)
        {
            Symbol = symbol;
            Index = index;
        }
        public char Symbol { get; set; }
            
        public int Index { get; set; }
    }
}