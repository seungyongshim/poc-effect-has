namespace Sample;

public static class Time<RT> where RT : struct, Has<DateTime>
{
    public static Eff<RT, DateTime> NowEff =>
        from time in Has<RT, DateTime>.Eff
        select time;
}
