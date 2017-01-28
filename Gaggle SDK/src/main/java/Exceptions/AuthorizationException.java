package Exceptions;

/**
 * Created by Victor on 28.01.2017.
 */
public class AuthorizationException extends Exception {
    public AuthorizationException() {

    }

    public AuthorizationException(String message) {
        super(message);
    }

    public AuthorizationException(String message, Exception exception) {
        super(message, exception);
    }
}
