package Helpers;

import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.math.BigDecimal;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.util.UUID;

/**
 * Created by Victor on 02.01.2017.
 */
public class Converter {
    public static byte[] toBytes(UUID value) {
        byte[] buffer = ByteBuffer.allocate(16).order(ByteOrder.LITTLE_ENDIAN).putLong(value.getMostSignificantBits()).putLong(value.getLeastSignificantBits()).array();
        return buffer;
    }

    public static byte[] toBytes(Byte value) {
        byte[] buffer = ByteBuffer.allocate(1).order(ByteOrder.LITTLE_ENDIAN).put(value).array();
        return buffer;
    }

    public static byte[] toBytes(Short value) {
        byte[] buffer = ByteBuffer.allocate(2).order(ByteOrder.LITTLE_ENDIAN).putShort(value).array();
        return buffer;
    }

    public static byte[] toBytes(Long value) {
        byte[] buffer = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putLong(value).array();
        return buffer;
    }

    public static byte[] toBytes(Float value) {
        byte[] buffer = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putFloat(value).array();
        return buffer;
    }

    public static byte[] toBytes(Double value) {
        byte[] buffer = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putDouble(value).array();
        return buffer;
    }

    public static byte[] toBytes(Boolean value) {
        byte[] buffer = ByteBuffer.allocate(1).order(ByteOrder.LITTLE_ENDIAN).put((byte) (value ? 1 : 0)).array();
        return buffer;
    }

    public static byte[] toBytes(Integer value) {
        byte[] buffer = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(value).array();
        return buffer;
    }

    public static byte[] toBytes(Character value) {
        byte[] buffer = ByteBuffer.allocate(1).order(ByteOrder.LITTLE_ENDIAN).putChar(value).array();
        return buffer;
    }

    public static byte[] toBytes(BigDecimal bigDecimal) {
        throw new NotImplementedException();
    }

    public static byte[] toBytes(Byte[] value) {
        byte[] buffer = new byte[value.length];

        for (int i = 0; i < buffer.length; i++) {
            buffer[i] = value[i];
        }

        return buffer;
    }
}
