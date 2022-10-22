using System;
using LanguageExt;
using static LanguageExt.Prelude;
using Xunit;
using System.Threading.Tasks;
using LanguageExt.Effects.Traits;
using System.Threading;

namespace Sample.Tests;



public class PreludeSpec
{
    [Fact]
    public async Task Fact()
    {
        var sut = DateTime.Now;
        using var cts = new CancellationTokenSource();
        var rt = new RT(() => sut, cts);

        var ret = await Business().Run(rt);

        Assert.Equal(sut, ret);


        static Aff<RT, DateTime> Business() =>
            from __ in unitEff
            from _1 in Time<RT>.NowEff
            select _1;
    }

    public readonly record struct RT(Func<DateTime> FuncDateTime, CancellationTokenSource CancellationTokenSource) :
        HasCancel<RT>,
        Has<DateTime>
    {
        public RT LocalCancel => this;
        public CancellationToken CancellationToken => CancellationTokenSource.Token;

        DateTime Has<DateTime>.It => FuncDateTime();
    }
}
