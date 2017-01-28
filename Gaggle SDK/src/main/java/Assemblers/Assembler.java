package Assemblers;

import Objects.User.User;

/**
 * Created by Victor on 28.01.2017.
 */
public class Assembler {
    public static <T> byte[] assembly(T entity) {
        return null;
    }

    public static <T extends User> T disassembly(Class<T> type, byte[] buffer) {
        return null;
    }
}
