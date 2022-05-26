using System.Globalization;
using System.Text;

class FunkyCalculator
{

    /*
     * 100/6=16,6^
     *  40
     *   40
     *
     *
     */
    public string DivideWithPeriod(double num, double divider)
    {
        StringBuilder result = new StringBuilder();
        string numString = num.ToString(CultureInfo.InvariantCulture);
        double currentDivSegment = num; //"Podtržená část při dělení"
        int currentDigitPointer = 0;

        bool addedSeparator = false; //extremni hack nevim jak to udelat lepe
        int separatorIndex = 0;

        //Získání nejmenšíh dělitelné části čísla
        for (var i = 1; i <= numString.Length; i++)
        {
            double subPart = double.Parse(numString.Substring(0, i));
            if (subPart > divider)
            {
                currentDivSegment = subPart;
                currentDigitPointer = i-1;
                break;
            }
        }

        HashSet<double> remainderSet = new HashSet<double>();
        while (true)
        {
            int div = (int)currentDivSegment / (int)divider;
            result.Append(div);
            double mod = currentDivSegment % divider;
            currentDigitPointer++;

            
            //Normalni cifry
            if(currentDigitPointer < numString.Length)
                currentDivSegment = double.Parse($"{mod}{numString[currentDigitPointer]}");
            
            else
            {
                //Desetinne cifry
                if (!addedSeparator)
                {
                    addedSeparator = true;
                    separatorIndex = currentDigitPointer+1;
                    result.Append(".");
                }
                currentDivSegment = mod * 10;
                if (remainderSet.Contains(currentDivSegment))
                {
                    //Opakovany zbytek po deleni
                    result.Insert(separatorIndex, '(');
                    result.Append(")");
                    break;
                }
                
                else 
                    remainderSet.Add(currentDivSegment);
                
            }
            if (mod == 0)
            {
                break;
            }
        }
        return result.ToString();
    }

}