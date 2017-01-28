package Objects.User;

/**
 * Created by Victor on 28.01.2017.
 */
public class User implements IUser {

    public String Name;

    @Override
    public void setName(String name) {
        Name = name;
    }

    @Override
    public String getName() {
        return Name;
    }
}
