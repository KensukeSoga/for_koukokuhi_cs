package jp.co.isid.ham.base;

import java.util.Properties;

import jp.co.isid.nj.util.config.Parameter;
import jp.co.isid.nj.util.config.ParameterFactory;


/**
 * <p>
 * HAM システムのパラメータクラス
 * </p>
 * <p>
 * <b>修正履歴</b><br />
 * ・新規作成(2006/09/22 WT H.Ikeda)<br />
 * ・HDX対応(2016/04/12 HLC K.Oki)<BR>
 * </p>
 *
 * @author WT H.Ikeda
 */
public class HAMParameter extends Parameter {

    /** serialVersionUID */
    private static final long serialVersionUID = -8517552208554056131L;
    /** システムコード */
    public static final String SYSTEM_CODE = "HAM";


    /**
     * デフォルトコンストラクタです
     * フレームワークにより呼び出されます
     */
    public HAMParameter() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static HAMParameter getInstance() {
        return (HAMParameter) ParameterFactory.getParameter(SYSTEM_CODE);
    }

    /**
     * データソースの使用有無を返します
     * @return trueの場合、データソースを使用する
     */
    public boolean isDataSourceUse() {
        String val = (String)getValue("SQLSDataSourceUse");
        return (val != null && "true".equals(val)) ? true : false;
    }

    /**
     * SQLServerデータソース名を返します
     * @return データソース名
     */
    public String getDataSourceName() {
        return (String)getValue("SQLSDataSourceName");
    }

    /**
     * JDBCDriver名を返します
     *
     * @return JDBCDriver名
     */
    public String getDBDriver() {
        return (String) getValue("DBDriver");
    }

    /**
     * データベース URL を返します
     *
     * @return データベース URL
     */
    public String getDBUrl() {
        return (String) getValue("DBUrl");
    }

    /**
     * DB 接続プロパティを返します
     *
     * @return Properties DB 接続プロパティ
     */
    public Properties getDriverProperties() {
        return toProperties((String) getValue("DBKey"), (String) getValue("DBParameter"));
    }

    /**
     * 業務会計JDBCDriver名を返します
     *
     * @return 業務会計JDBCDriver名
     */
    public String getECDBDriver() {
        return (String) getValue("ECDBDriver");
    }

    /**
     * 業務会計データベースURLを返します
     *
     * @return 業務会計データベースURL
     */
    public String getECDBUrl() {
        return (String) getValue("ECDBUrl");
    }

    /**
     * 業務会計DB接続プロパティを返します
     *
     * @return 業務会計DB接続プロパティ
     */
    public Properties getECDriverProperties() {
        return toProperties((String) getValue("ECDBKey"), (String) getValue("ECDBParameter"));
    }

    /**
     * コンマ区切りのキーと値をPropertiesオブジェクトに変換して返します
     *
     * @param strKeys String キーのコンマ区切り文字列
     * @param strValues String 値のコンマ区切り文字列
     * @return Properties 変換後のPropertiesオブジェクト
     */
    private Properties toProperties(String strKeys, String strValues) {
        Properties props = null;
        String[] keys = getCommaString2Array(strKeys);
        String[] values = getCommaString2Array(strValues);
        // パラメータのセット
        if (haveKeys(keys)) {
            props = new Properties();
            for (int i = 0; i < keys.length; i++) {
                props.setProperty(keys[i], values[i]);
            }
        }
        return props;
    }

    /**
     * キーを保持しているかを判定します
     *
     * @param keys String[] キー
     * @return true:保持している false:保持していない
     */
    private boolean haveKeys(String[] keys) {
        return (keys != null) && (keys.length != 0);
    }

    /**
     * CommandInvoker 名を返します
     * @return CommandInvoker 名
     */
    public String getCommandInvokerName() {
        return "forServer";
    }

    /**
     * log4j.xml のパスを返します
     * @return log4j.xml のパス
     */
    public String getLog4jXMLPath() {
        return (String) getValue("Log4jXMLPath");
    }

    /**
     * SMTPサーバーのサーバー名(orアドレス) を返します
     *
     * @return SMTPサーバーのサーバー名(orアドレス)
     */
    public String getSmtpHost() {
        return (String) getValue("SmtpHost");
    }

    /**
     * SMTPサーバーのポート番号を返します
     *
     * @return SMTPサーバーのポート番号
     */
    public String getSmtpPort() {
        return (String) getValue("SmtpPort");
    }

    /* 2016/04/12 HDX対応 HLC K.Oki ADD Start */
    /**
     * 業務会計データソースの使用有無を返します
     * @return trueの場合、データソースを使用する
     */
    public boolean isECDataSourceUse() {
        String val = (String)getValue("ECSQLSDataSourceUse");
        return (val != null && "true".equals(val)) ? true : false;
    }

    /**
     * 業務会計SQLServerデータソース名を返します
     * @return データソース名
     */
    public String getECDataSourceName() {
        return (String)getValue("ECSQLSDataSourceName");
    }
    /* 2016/04/12 HDX対応 HLC K.Oki ADD End */

}
