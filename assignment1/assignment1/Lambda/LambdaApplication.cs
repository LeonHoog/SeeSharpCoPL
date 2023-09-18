using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1.Lambda;
internal class LambdaApplication : ILambdaExpression
{
    public required ILambdaExpression Function { get; set; }
    public required ILambdaExpression Argument { get; set; }
}
