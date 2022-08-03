public class StartUp
{
    static void Main(string[] args)
    {
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(5, 10);
        axe.Attack(dummy);
        dummy.GiveExperience();
    }
}
