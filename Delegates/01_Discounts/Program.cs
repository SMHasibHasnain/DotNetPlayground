class Program
{

    public static void Main(String[] args)
    {
        ApplyDiscount applyDiscount = new ApplyDiscount();
        Discount discount = new Discount();

        applyDiscount.Apply(discount.RegularDiscount, 20, 15);
        applyDiscount.Apply(discount.VIPDiscount, 30, 40);

    }
}

class ApplyDiscount()
{

    public delegate double voucher(double min, double max);
    public void Apply(voucher discount, double max, double min)
    {
        double amount = discount(max, min);
        System.Console.WriteLine(amount);
    }
}


class Discount
{
    public double RegularDiscount(double min, double max)
    {
        return DiscountCalculation(min, max);
    }

    public double VIPDiscount(double min, double max)
    {
        return DiscountCalculation(min, max);
    }

    public double DiscountCalculation(double min, double max)
    {
        double random = Random.Shared.NextDouble();
        return min + (random * (max-min));
    }
}