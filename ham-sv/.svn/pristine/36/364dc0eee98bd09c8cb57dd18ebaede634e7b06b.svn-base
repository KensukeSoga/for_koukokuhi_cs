package jp.co.isid.ham.integ.util;

import java.util.Properties;

import jp.co.isid.ham.base.HAMParameter;
import jp.co.isid.nj.integ.sql.PoolConnect;

/**
 *
 * <P>業務会計コネクション取得クラス</P>
 * <P>
 * 業務会計コネクションクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/09/10 JSE H.Abe)<BR>
 * ・HDX対応(2016/04/12 HLC K.Oki)<BR>
 * </P>
 * @author JSE H.Abe
 */
public class ECPoolConnect extends PoolConnect {

    /** パラメータ */
    private static HAMParameter _param = HAMParameter.getInstance();

    /**
     * 新規インスタンスを構築します
     */
    public ECPoolConnect() {
    }

    /**
     * データソースを使用するかどうかを返します
     *
     * @return true:使用する false:使用しない
     */
    
    public boolean isDataSourceUse() {
        /* 2016/04/12 HDX対応 HLC K.Oki MOD Start */
        //return _param.isDataSourceUse();
    
        return _param.isECDataSourceUse();
        /* 2016/04/12 HDX対応 HLC K.Oki MOD End */
    }
    

    /**
     * DriverPropertiesを返します
     *
     * @return Properties
     */
    public Properties getDriverProperties() {
        return _param.getECDriverProperties();
    }

    /**
     * JDBCDriver名を返します
     *
     * @return JDBCDriver名
     */
    public String getJDBCDriver() {
        return _param.getECDBDriver();
    }

    /**
     * DataSource名を返します
     *
     * @return DataSource名
     */
    public String getDataSourceName() {
        /* 2016/04/12 HDX対応 HLC K.Oki MOD Start */
        //return _param.getDataSourceName();
        
        return _param.getECDataSourceName();
        /* 2016/04/12 HDX対応 HLC K.Oki MOD End */
    }

    /**
     * URLを返します
     *
     * @return URL
     */
    public String getURL() {
        return _param.getECDBUrl();
    }

}
