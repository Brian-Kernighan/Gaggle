package Network;

import Exceptions.AuthorizationException;
import Exceptions.RegistrationException;

/**
 * Created by Victor on 30.12.2016.
 */
public interface IServiceMethods {
    void logoff();

    void register(String email, String password, String name) throws RegistrationException;

    byte[] authorize(String email, String password) throws AuthorizationException;
}
