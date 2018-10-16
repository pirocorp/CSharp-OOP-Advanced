namespace P01_GenericBoxOfString
{
    public class Box<T>
    {
        private readonly T element;

        public Box(T element)
        {
            this.element = element;
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {this.element}";
        }
    }
}