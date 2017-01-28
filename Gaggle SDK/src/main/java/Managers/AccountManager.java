package Managers;

import Assemblers.Assembler;
import Common.Gaggle;
import Exceptions.AuthorizationException;
import Exceptions.RegistrationException;
import Network.ServiceMethods;
import Objects.User.User;

/**
 * Created by Victor on 06.01.2017.
 */
public class AccountManager {
    private Gaggle _gaggle;

    private ServiceMethods _serviceMethods;

    public AccountManager(Gaggle gaggle, ServiceMethods serviceMethods) {
        _gaggle = gaggle;
        _serviceMethods = serviceMethods;
    }

    public User login(String email, String password) throws AuthorizationException {
        User user = Assembler.disassembly(User.class, _serviceMethods.authorize(email, password));
        return user;
    }

    public void logoff() {
        //
        _serviceMethods.logoff();
    }

    public void register(String email, String password, String name) throws RegistrationException {
        //
        _serviceMethods.register(email, password, name);
    }
}
