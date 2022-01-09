using Shift.Server.Context;

namespace Shift.Server.Middleware
{
    public class FeryvContextMiddleware : BaseContextMiddleware<FeryvContextMiddleware, FeryvContext>
    {
        public FeryvContextMiddleware(ILogger<FeryvContextMiddleware> logger, FeryvContext feryvContext) : base(logger, feryvContext)
        {
        }
    }
}