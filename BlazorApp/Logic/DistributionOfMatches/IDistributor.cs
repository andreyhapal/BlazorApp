using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Logic.DistributionOfMatches
{
    public interface IDistributor
    {
        List<Match> Mix(List<Dictionary<int, int>> list, int medium, List<Tatami> tatamis, List<Match> matches);
    }

    public enum DivisionParameter
    {
        DivisionAllowed,
        DivisionNotAllowed
    }
}
