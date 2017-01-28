package Common;

import Managers.AccountManager;
import Network.ServiceMethods;
import org.zeromq.ZMQ;

import java.io.Closeable;

/**
 * Created by Victor on 02.01.2017.
 */
public class Gaggle implements Closeable {
    private ZMQ.Socket _socket;
    private ZMQ.Context _context;

    final private String AUTH_ENDPOINT = "tcp://127.0.0.1:5554";
    final private String SERVER_ENDPOINT = "tcp://127.0.0.1:5555";

    private AccountManager _accountManager;

    public Gaggle() {
        authenticate();
    }

    public void close() {
        _socket.close();
        _context.term();
    }

    public AccountManager getAccountManager() {
        if (_accountManager == null) {
            _accountManager = new AccountManager(this, new ServiceMethods(_socket));
        }
        return _accountManager;
    }

    private void authenticate() {
        //todo: Read about IO zmq threads.
        _context = ZMQ.context(1);

        _socket = _context.socket(ZMQ.DEALER);

        _socket.connect(SERVER_ENDPOINT);
    }
}