package Network;

import Enums.TypeCode;
import Exceptions.AuthorizationException;
import Exceptions.RegistrationException;
import Helpers.Converter;
import org.joda.time.DateTime;
import org.joda.time.DateTimeZone;
import org.zeromq.ZMQ;

import java.io.UnsupportedEncodingException;
import java.math.BigDecimal;
import java.util.UUID;

/**
 * Created by Victor on 30.12.2016.
 */
public class ServiceMethods implements IServiceMethods {
    //----

    private ZMQ.Socket _socket;

    //----

    public ServiceMethods(ZMQ.Socket socket) {
        _socket = socket;
    }

    //-----

    @Override
    public void logoff() {
        RequestServer("Logoff");
        byte[] buffer = _socket.recv();
    }

    @Override
    public void register(String email, String password, String name) throws RegistrationException {
        RequestServer("Register", email, password, name);

        byte[] buffer = _socket.recv();

        //todo: parser buffer for exception
        //todo: throw exception if server returned the error
    }

    @Override
    public byte[] authorize(String email, String password) throws AuthorizationException {
        RequestServer("Authorize", email, password);
        byte[] buffer = _socket.recv();
        return buffer;
        //todo: parser buffer for exception
        //todo: throw exception if server returned the error
    }

    //----

    private void RequestServer(Object... parameters) {
        for (Object parameter : parameters) {
            Class clazz = parameter.getClass();

            TypeCode typeCode = GetTypeCode(clazz);

            switch (typeCode) {
                case Empty: {
                    throw new IllegalArgumentException(String.format("Invalid parameter type \"%1s\"", typeCode));
                }

                case Char:
                case Byte:
                case SByte: {
                    _socket.sendMore(Converter.toBytes((Byte) parameter));
                }
                break;

                case UUID: {
                    _socket.sendMore(Converter.toBytes((UUID) parameter));
                }
                break;

                case Int16: {
                    _socket.sendMore(Converter.toBytes((Short) parameter));
                }
                break;

                case Int32: {
                    _socket.sendMore(Converter.toBytes((Integer) parameter));
                }
                break;

                case Int64: {
                    _socket.sendMore(Converter.toBytes((Long) parameter));
                }
                break;

                case UInt16: {
                    _socket.sendMore(Converter.toBytes((Short) parameter));
                }
                break;

                case UInt32: {
                    _socket.sendMore(Converter.toBytes((Integer) parameter));
                }
                break;

                case UInt64: {
                    _socket.sendMore(Converter.toBytes((Long) parameter));
                }
                break;

                case Single: {
                    throw new IllegalArgumentException(String.format("Invalid parameter type \"%1s\"", typeCode));
                }

                case String: {
                    try {
                        byte[] buffer = ((String) parameter).getBytes("UTF-16LE");
                        _socket.sendMore(buffer);
                    } catch (UnsupportedEncodingException e) {
                        e.printStackTrace();
                    }
                }
                break;

                case Object: {
                    //todo: Serialize here protobuf messages
                    _socket.sendMore(new byte[1]);
                }
                break;

                case Double: {
                    _socket.sendMore(Converter.toBytes((Double) parameter));
                }
                break;

                case Decimal: {
                    _socket.sendMore(Converter.toBytes((BigDecimal) parameter));
                }
                break;

                case Boolean: {
                    _socket.sendMore(Converter.toBytes((Boolean) parameter));
                }
                break;

                case DateTime: {
                    DateTime timeValue = (DateTime) parameter;
                    long millis = timeValue.withZone(DateTimeZone.UTC).getMillis();
                    byte[] buffer = Converter.toBytes(millis);
                    _socket.sendMore(buffer);
                }
                break;

                case ByteArray: {
                    Byte[] buffer = (Byte[]) parameter;

                    _socket.sendMore(Converter.toBytes(buffer));
                }
                break;
            }
        }

        _socket.send("");
    }

    private TypeCode GetTypeCode(Class clazz) {
        String typeName = clazz.getSimpleName();

        if (typeName.equals("Char")) {
            return TypeCode.Char;
        }

        if (typeName.equals("Byte")) {
            return TypeCode.Byte;
        }

        if (typeName.equals("SByte")) {
            return TypeCode.SByte;
        }

        if (typeName.equals("UUID")) {
            return TypeCode.UUID;
        }

        if (typeName.equals("Int16")) {
            return TypeCode.Int16;
        }

        if (typeName.equals("Int32")) {
            return TypeCode.Int32;
        }

        if (typeName.equals("Int64")) {
            return TypeCode.Int64;
        }

        if (typeName.equals("UInt16")) {
            return TypeCode.UInt16;
        }

        if (typeName.equals("UInt32")) {
            return TypeCode.UInt32;
        }

        if (typeName.equals("UInt64")) {
            return TypeCode.UInt64;
        }

        if (typeName.equals("Byte[]")) {
            return TypeCode.ByteArray;
        }

        if (typeName.equals("String")) {
            return TypeCode.String;
        }

        if (typeName.equals("DateTime")) {
            return TypeCode.DateTime;
        }

        return TypeCode.Empty;
    }

    //----
}