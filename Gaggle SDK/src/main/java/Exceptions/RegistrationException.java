package Exceptions;

/**
 * Created by Victor on 28.01.2017.
 */
public class RegistrationException extends Exception {
    public RegistrationException() {

    }

    public RegistrationException(String message) {
        super(message);
    }

    public RegistrationException(String message, Exception exception) {
        super(message, exception);
    }
}
