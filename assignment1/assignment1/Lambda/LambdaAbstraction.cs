using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.Lambda;
internal class LambdaAbstraction : ILambdaExpression
{
    public required string Name { get; set; }
    public required ILambdaExpression Body { get; set; }
}
