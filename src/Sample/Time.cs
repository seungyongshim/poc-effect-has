namespace Sample;

public static class Time<RT> where RT : struct, Has<DateTime>
{
    public static Eff<RT, DateTime> NowEff =>
        from time in Service<RT, DateTime>.Eff
        select time;
}
