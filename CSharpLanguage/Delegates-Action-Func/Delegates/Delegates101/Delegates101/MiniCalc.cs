namespace Delegates101
{
    //delegate defines the sig. - which matches the NumberChangerDelegateExample static methods
    delegate int NumberChanger(int n);

    public class MiniCalc
    {
        static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        public static void setNum(int i)
        {
            num=i;
        }
        
    }

}

