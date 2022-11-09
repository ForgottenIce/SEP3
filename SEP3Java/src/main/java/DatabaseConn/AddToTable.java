package DatabaseConn;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class AddToTable {
    ConnInfo connInfoWH1 = new ConnInfo();
    private final String urlWH1 = connInfoWH1.getUrlWarehouse1();
    private final String userWH1 = connInfoWH1.getUrlWarehouse1();
    private final String passwordWH1 = connInfoWH1.getPasswordWarehouse1();

    ConnInfo connInfoWH2 = new ConnInfo();
    private final String urlWH2 = connInfoWH2.getUrlWarehouse2();
    private final String userWH2 = connInfoWH2.getUserWarehouse2();
    private final String passwordWH2 = connInfoWH2.getPasswordWarehouse2();

    ConnInfo connInfoMS = new ConnInfo();
    private final String urlMS = connInfoMS.getUrlMS();
    private final String userMS = connInfoMS.getUserMS();
    private final String passwordMS = connInfoMS.getPasswordMS();

    public Connection connectWH1() throws SQLException {
        return DriverManager.getConnection(urlWH1, userWH1, passwordWH1);

    }

    public Connection connectWH2() throws SQLException {
        return DriverManager.getConnection(urlWH2, userWH2, passwordWH2);
    }

    public Connection connectMS() throws SQLException {
        return DriverManager.getConnection(urlMS, userMS, passwordMS);
    }
}