namespace Vector
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Vector vector = new Vector(4);

            vector.Append(0);
            vector.Append(1);
            vector.Append(2);
            vector.Append(3);

            vector.Print();
        }
    }
}