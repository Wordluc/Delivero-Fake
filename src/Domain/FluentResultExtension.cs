using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal static class FluentResultExtension
    {
        public static Result And (this Result firstResult,Result nextResult)
        {
            if (firstResult.IsFailed) return firstResult;
            return nextResult;
        }
    }
}
