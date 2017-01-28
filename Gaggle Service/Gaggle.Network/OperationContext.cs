using System;

namespace GaggleService.Network
{
    public class OperationContext
    {
        public static void Execute(Action callback, string methodName, params object[] args)
        {
            try
            {
                callback.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("CALL TIME \"{0}\" OF \"{1}\"", DateTime.UtcNow, methodName);
            }
        }
    }

    public class OperationContext<T>
    {
        public static T Execute(Func<T> callback, string methodName, params object[] args)
        {
            try
            {
                return callback.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
            finally
            {
                Console.WriteLine("CALL TIME \"{0}\" OF \"{1}\"", DateTime.UtcNow, methodName);
            }
        }

        internal static byte[] Execute(Func<byte[]> p, string v, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
