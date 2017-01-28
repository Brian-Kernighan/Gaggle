import Common.Gaggle;
import Exceptions.AuthorizationException;
import Exceptions.RegistrationException;
import Objects.User.IUser;

/**
 * Created by Victor on 26.12.2016.
 */
public class Main {
    public static void main(String[] args) {
        Gaggle gaggle = new Gaggle();

        try {
            gaggle.getAccountManager().register("victor.chicu@hotmail.com", "QAZxcv321ZAQ!2wsx", "Gaggle");
        } catch (RegistrationException e) {
            e.printStackTrace();
        }

        try {
            IUser user = gaggle.getAccountManager().login("victor.chicu@hotmail.com", "QAZxcv321ZAQ!2wsx");


        } catch (AuthorizationException e) {
            e.printStackTrace();
        }
    }
}