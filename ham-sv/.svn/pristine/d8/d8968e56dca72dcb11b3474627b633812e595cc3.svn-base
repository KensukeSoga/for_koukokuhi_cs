package jp.co.isid.ham.integ.util;

import java.util.Properties;

import jp.co.isid.ham.base.HAMParameter;
import jp.co.isid.nj.integ.sql.PoolConnect;

/**
 *
 * <P>コネクション取得クラス</P>
 * <P>
 * HAMコネクションクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2011/11/01 HLC sonobe)<BR>
 * </P>
 * @author HLC sonobe
 */
public class HAMPoolConnect extends PoolConnect {

    /** パラメータ */
    private static HAMParameter _param = HAMParameter.getInstance();

    /**
     * 新規インスタンスを構築します
     */
    public HAMPoolConnect() {
    }

    /**
     * データソースを使用するかどうかを返します
     *
     * @return true:使用する false:使用しない
     */
    public boolean isDataSourceUse() {
        return _param.isDataSourceUse();
    }

    /**
     * DriverPropertiesを返します
     *
     * @return Properties
     */
    public Properties getDriverProperties() {
        return _param.getDriverProperties();
    }

    /**
     * JDBCDriver名を返します
     *
     * @return JDBCDriver名
     */
    public String getJDBCDriver() {
        return _param.getDBDriver();
    }

    /**
     * DataSource名を返します
     *
     * @return DataSource名
     */
    public String getDataSourceName() {
        return _param.getDataSourceName();
    }

    /**
     * URLを返します
     *
     * @return URL
     */
    public String getURL() {
        return _param.getDBUrl();
    }

}
