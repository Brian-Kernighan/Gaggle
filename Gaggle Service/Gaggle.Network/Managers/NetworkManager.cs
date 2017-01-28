using GaggleService.Gaggle.Exceptions;
using GaggleService.Gaggle.Network.Builders;
using GaggleService.Gaggle.Network.Caches;
using GaggleService.Network;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Text;
using System.Threading;

namespace GaggleService.Gaggle.Network.Managers
{
    public class NetworkManager
    {
        //todo: \"private static Type _guidType = typeof(Guid);\" Biggest shit! Rework it.,
        //todo: Read about SignalError methods. What is doing?

        private static Type _guidType = typeof(Guid);

        public static void StartNeuralNetwork(string listenEndpoint, CancellationTokenSource cancellationTokenSource)
        {
            var serviceMethods = Activator.CreateInstance<ServiceMethods>();

            ServiceMethodsCache.Create(serviceMethods);

            using (var routerSocket = new RouterSocket(listenEndpoint))
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        var socketIdentity = routerSocket.ReceiveFrameBytes(out var more);

                        if (!more)
                        {
                            routerSocket.SignalError();
                        }

                        var methodName = routerSocket.ReceiveFrameString(Encoding.Unicode, out more);

                        if (!more)
                        {
                            routerSocket.SignalError();
                        }

                        if (!ServiceMethodsCache.TryGetValue(methodName, out var methodInfo))
                        {
                            throw new Exception("Failed to get method info from service methods cache");
                        }

                        var parametersInfo = methodInfo.GetParameters();
      
                        var parametersBuilder = new ParametersBuilder();

                        foreach (var parameterInfo in parametersInfo)
                        {
                            if (parameterInfo.ParameterType.Equals(_guidType))
                            {
                                var frameBytes = ReceiveFrameBytes(routerSocket, TypeCode.Object);

                                parametersBuilder.Append(new Guid(frameBytes));
                            }
                            else
                            {
                                var typeCode = Type.GetTypeCode(parameterInfo.ParameterType);

                                switch (typeCode)
                                {
                                    case TypeCode.Empty:
                                        {
                                            throw new TypeMismatchException("Parameter is empty or not valid");
                                        }

                                    case TypeCode.Char:
                                        {
                                            var value = Convert.ToChar(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Byte:
                                        {
                                            var value = Convert.ToByte(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.SByte:
                                        {
                                            var value = Convert.ToSByte(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Int16:
                                        {
                                            var value = Convert.ToInt16(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Int32:
                                        {
                                            var value = Convert.ToInt32(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Int64:
                                        {
                                            var value = Convert.ToInt64(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.UInt16:
                                        {
                                            var value = Convert.ToUInt16(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.UInt32:
                                        {
                                            var value = Convert.ToUInt32(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.UInt64:
                                        {
                                            var value = Convert.ToUInt64(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Object:
                                        {
                                            var frameBytes = ReceiveFrameBytes(routerSocket, typeCode);
                                            //todo: protobuf
                                        }
                                        break;

                                    case TypeCode.Single:
                                        {
                                            var value = Convert.ToSingle(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.String:
                                        {
                                            string value = ReceiveFrameString(routerSocket, typeCode);
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Double:
                                        {
                                            var value = Convert.ToDouble(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Decimal:
                                        {
                                            var value = Convert.ToDecimal(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.Boolean:
                                        {
                                            var value = Convert.ToBoolean(ReceiveFrameBytes(routerSocket, typeCode));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    case TypeCode.DateTime:
                                        {
                                            var value = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(ReceiveFrameBytes(routerSocket, typeCode), 0));
                                            parametersBuilder.Append(value);
                                        }
                                        break;

                                    default:
                                        {
                                            throw new Exception("Parameter is unknown or not valid");
                                        }
                                }
                            }
                        }

                        var result = methodInfo.Invoke(serviceMethods, parametersBuilder.Build());

                        //todo: Определить возвращаемый методом тип
                        //todo: Упаковать все красиво в массив байт новомодным protobuf
                        //todo: Передать обратно сериализованный объект как ответ

                        routerSocket.SendFrame(string.Empty);
                    }
                    catch (Exception exception)
                    {
                        //todo: Manage exceptions
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        private static byte[] ReceiveFrameBytes(RouterSocket routerSocket, TypeCode typeCode)
        {
            if (!routerSocket.TryReceiveFrameBytes(out var frameBytes))
            {
                throw new NetMQException(string.Format("Failed to read \"{0}\" parameter from router socket", typeCode));
            }

            return frameBytes;
        }

        private static string ReceiveFrameString(RouterSocket routerSocket, TypeCode typeCode)
        {
            if (!routerSocket.TryReceiveFrameString(Encoding.Unicode, out var frameString))
            {
                throw new NetMQException(string.Format("Failed to read \"{0}\" parameter from router socket", typeCode));
            }

            return frameString;
        }
    }
}
