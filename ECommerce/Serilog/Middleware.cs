//using Serilog.Context;

//namespace ECommerce.Serilog
//{
//    public class Middleware
//    {
//        private readonly RequestDelegate next;


//        public Middleware(RequestDelegate next)
//        {
//            this.next = next;
//        }
//        public async Task Invoke(HttpContext context)
//        {
//            var result = context.User.Identity.Name;
//            if (result == null)
//            {
//                result = "System";
//            }
//            LogContext.PushProperty("UserName", result);
//            await next(context);
//        }
//    }
//}