using System.Text;

class FunkyCalculator
{

    public string DivideWithPeriod(double num, double divider)
    {
        if (divider == 0)
            throw new DivideByZeroException();

        StringBuilder result = new StringBuilder();
        List<double> rememberedRemainder = new List<double>();
        string digits = num.ToString();

        double currentDividePart = num;
        int digitPointer = 0;
        int digitsBeforePeriod = 0;
        bool addedDecimalPoint = false;

        //Find the smallest divide segment 100,0
        for (int i = 1; i < digits.Length+1; i++,digitPointer++)
        {
            currentDividePart = double.Parse(digits.Substring(0,i));
            if (divider < currentDividePart)
            {
                break;
            }
        }

        while (true)
        {
            digitPointer++;
            int div = (int) currentDividePart / (int) divider;
            int mod = (int) currentDividePart % (int) divider;

            result.Append(div);

            //No more digits, must give zeros now
            if (digitPointer > digits.Length-1)
            {
                if (!addedDecimalPoint)
                {
                    result.Append('.');
                    addedDecimalPoint = true;
                }
                currentDividePart = mod * 10;
                //We hit the end of the period
                if (rememberedRemainder.Contains(mod))
                {
                    result.Insert(rememberedRemainder.IndexOf(mod) + 2 + digitsBeforePeriod, '(');
                    result.Append(')');
                    break;
                }
                else
                {
                    rememberedRemainder.Add(mod);
                }
            }
            //We have digits, use them in the next dividing
            else
            {
                digitsBeforePeriod++;
                currentDividePart = double.Parse($"{mod}{digits[digitPointer]}");
            }
            if (mod == 0)
            {
                break;
            }
        }
        return result.ToString();
    }


}