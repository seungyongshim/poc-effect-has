namespace Sample;

public static class Service<RT, TService> where RT : struct, Has<TService>
{
    public static Eff<RT, TService> Eff => EffMaybe<RT, TService>(rt => rt.It);
}
