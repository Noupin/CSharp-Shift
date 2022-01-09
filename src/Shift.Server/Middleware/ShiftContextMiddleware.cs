using Shift.Server.Context;

namespace Shift.Server.Middleware
{
    public class ShiftContextMiddleware : BaseContextMiddleware<ShiftContextMiddleware, ShiftContext>
    {
        public ShiftContextMiddleware(ILogger<ShiftContextMiddleware> logger, ShiftContext shiftContext) : base(logger, shiftContext)
        {
        }
    }
}