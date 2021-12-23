namespace HW13Benchmark
{
    public class Methods
    {
        public string Simple(string num)
        {
            num += num;
            return num;
        }

        public virtual string Virtual(string num)
        {
            num += num;
            return num;
        }

        public static string Static(string num)
        {
            num += num;
            return num;
        }

        public string Generic<T>(T num)
        {
            return num.ToString() + num;
        }

        public string Dynamic(dynamic num)
        {
            num += num.ToString();
            return num;
        }

        public string Reflection(string num)
        {
            num += num;
            return num;
        }
    }
}