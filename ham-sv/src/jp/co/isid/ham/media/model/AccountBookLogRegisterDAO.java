package jp.co.isid.ham.media.model;

import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.tbl.Tbj23LogEigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
*
* <P>
* 営業作業台帳の情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/14 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.Watabe
*/
public class AccountBookLogRegisterDAO extends AbstractSimpleRdbDao{

    private String _daichoNO = null;
    private String _rirekiNm = null;

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode {
        INS,DEL
    };

    private ExecSqlMode _ExecSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public AccountBookLogRegisterDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }


    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return new String[]{
                Tbj23LogEigyoDaicho.MEDIAPLANNO,
                Tbj23LogEigyoDaicho.DAICHONO,
                Tbj23LogEigyoDaicho.HISTORYNO
        };

    }


    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {

        return null;

    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj23LogEigyoDaicho.TBNAME;

    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj23LogEigyoDaicho.MEDIAPLANNO
                ,Tbj23LogEigyoDaicho.DAICHONO
                ,Tbj23LogEigyoDaicho.HISTORYNO
                ,Tbj23LogEigyoDaicho.HISTORYKBN
                ,Tbj23LogEigyoDaicho.IMPKEY
                ,Tbj23LogEigyoDaicho.SEIKYUYM
                ,Tbj23LogEigyoDaicho.MEDIACD
                ,Tbj23LogEigyoDaicho.MEDIASCD
                ,Tbj23LogEigyoDaicho.MEDIASNM
                ,Tbj23LogEigyoDaicho.KEIRETSUCD
                ,Tbj23LogEigyoDaicho.DCARCD
                ,Tbj23LogEigyoDaicho.HIYOUNO
                ,Tbj23LogEigyoDaicho.KIKAKUNO
                ,Tbj23LogEigyoDaicho.CAMPAIGN
                ,Tbj23LogEigyoDaicho.NAIYOHIMOKU
                ,Tbj23LogEigyoDaicho.SPACE
                ,Tbj23LogEigyoDaicho.NPDIVISION
                ,Tbj23LogEigyoDaicho.PUBLISHVER
                ,Tbj23LogEigyoDaicho.SYMBOLDIVISION
                ,Tbj23LogEigyoDaicho.POSTEDSURFACE
                ,Tbj23LogEigyoDaicho.UNIT
                ,Tbj23LogEigyoDaicho.CONTRACTDIVISION
                ,Tbj23LogEigyoDaicho.KIKANFROM
                ,Tbj23LogEigyoDaicho.KIKANTO
                ,Tbj23LogEigyoDaicho.GENKAFLG
                ,Tbj23LogEigyoDaicho.GROSS
                ,Tbj23LogEigyoDaicho.DNEBIKIRITSU
                ,Tbj23LogEigyoDaicho.DNEBIKIGAKU
                ,Tbj23LogEigyoDaicho.HMCOST
                ,Tbj23LogEigyoDaicho.APLRIEKIRITSU
                ,Tbj23LogEigyoDaicho.APLRIEKIGAKU
                ,Tbj23LogEigyoDaicho.MEDIAHARAI
                ,Tbj23LogEigyoDaicho.MEDIAMARGINRITSU
                ,Tbj23LogEigyoDaicho.MEDIAMARGINGAKU
                ,Tbj23LogEigyoDaicho.MEDIAGENKA
                ,Tbj23LogEigyoDaicho.TORIRIEKI
                ,Tbj23LogEigyoDaicho.RIEKIHAIBUN
                ,Tbj23LogEigyoDaicho.NAIKINRIEKI
                ,Tbj23LogEigyoDaicho.FURIKAERIEKI
                ,Tbj23LogEigyoDaicho.EIGYOYOIN
                ,Tbj23LogEigyoDaicho.FURIKAERIEKI2
                ,Tbj23LogEigyoDaicho.TVTMEDIATANKA
                ,Tbj23LogEigyoDaicho.TVTHMTANKA
                ,Tbj23LogEigyoDaicho.COLORFEE
                ,Tbj23LogEigyoDaicho.DESIGNATIONFEE
                ,Tbj23LogEigyoDaicho.DOUBLEFEE
                ,Tbj23LogEigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj23LogEigyoDaicho.SPACEFEE
                ,Tbj23LogEigyoDaicho.SPLITRUNFEE
                ,Tbj23LogEigyoDaicho.REQUESTDESTINATION
                ,Tbj23LogEigyoDaicho.BRDDATE
                ,Tbj23LogEigyoDaicho.BIKO
                ,Tbj23LogEigyoDaicho.SEIKYUFLG
                ,Tbj23LogEigyoDaicho.CPDATE
                ,Tbj23LogEigyoDaicho.BRDSEC
                ,Tbj23LogEigyoDaicho.FILEOUTFLG
                ,Tbj23LogEigyoDaicho.APPEARANCEDATE
                ,Tbj23LogEigyoDaicho.SORTNO
                ,Tbj23LogEigyoDaicho.CRTDATE
                ,Tbj23LogEigyoDaicho.CRTNM
                ,Tbj23LogEigyoDaicho.CRTAPL
                ,Tbj23LogEigyoDaicho.CRTID
                ,Tbj23LogEigyoDaicho.UPDDATE
                ,Tbj23LogEigyoDaicho.UPDNM
                ,Tbj23LogEigyoDaicho.UPDAPL
                ,Tbj23LogEigyoDaicho.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        if (_ExecSqlMode.equals(ExecSqlMode.INS)) {
            return getInsAccountBookHistory();
        }
        else if (_ExecSqlMode.equals(ExecSqlMode.DEL)) {
            return getDelAccountBookHistory();
        }
        return null;

    }

    /**
     * 対象の営業作業台帳ログを削除します
     *
     * @return 削除SQL文
     */
    public String getDelAccountBookHistory() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Tbj23LogEigyoDaicho.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj23LogEigyoDaicho.DAICHONO + " ='" + _daichoNO + "' ");

        return sql.toString();
    }

    public String getInsAccountBookHistory() {
        StringBuffer sql = new StringBuffer();

        sql.append(" INSERT INTO ");
        sql.append("    " + Tbj23LogEigyoDaicho.TBNAME + " ");
        sql.append(" ( ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" ) ");
        sql.append(" SELECT ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " ");
        sql.append(" ," + Tbj02EigyoDaicho.DAICHONO + " ");
        sql.append(" ,(");
        sql.append(" SELECT ");
        sql.append(" NVL(MAX(" + Tbj23LogEigyoDaicho.HISTORYNO + "), 0) + 1 ");
        sql.append(" FROM ");
        sql.append(" " + Tbj23LogEigyoDaicho.TBNAME);
        sql.append(" WHERE ");
        sql.append(" " + Tbj23LogEigyoDaicho.DAICHONO + " = '" + _daichoNO + "' ");
        sql.append(" )");
        sql.append(" ," + getDBModelInterface().ConvertToDBString(_rirekiNm) + " ");
        sql.append(" ," + Tbj02EigyoDaicho.IMPKEY + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SEIKYUYM + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIACD + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIASCD + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIASNM + " ");
        sql.append(" ," + Tbj02EigyoDaicho.KEIRETSUCD + " ");
        sql.append(" ," + Tbj02EigyoDaicho.DCARCD + " ");
        sql.append(" ," + Tbj02EigyoDaicho.HIYOUNO + " ");
        sql.append(" ," + Tbj02EigyoDaicho.KIKAKUNO + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CAMPAIGN + " ");
        sql.append(" ," + Tbj02EigyoDaicho.NAIYOHIMOKU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SPACE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.NPDIVISION + " ");
        sql.append(" ," + Tbj02EigyoDaicho.PUBLISHVER + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SYMBOLDIVISION + " ");
        sql.append(" ," + Tbj02EigyoDaicho.POSTEDSURFACE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.UNIT + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CONTRACTDIVISION + " ");
        sql.append(" ," + Tbj02EigyoDaicho.KIKANFROM + " ");
        sql.append(" ," + Tbj02EigyoDaicho.KIKANTO + " ");
        sql.append(" ," + Tbj02EigyoDaicho.GENKAFLG + " ");
        sql.append(" ," + Tbj02EigyoDaicho.GROSS + " ");
        sql.append(" ," + Tbj02EigyoDaicho.DNEBIKIRITSU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.DNEBIKIGAKU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.HMCOST + " ");
        sql.append(" ," + Tbj02EigyoDaicho.APLRIEKIRITSU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.APLRIEKIGAKU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIAHARAI + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIAMARGINRITSU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIAMARGINGAKU + " ");
        sql.append(" ," + Tbj02EigyoDaicho.MEDIAGENKA + " ");
        sql.append(" ," + Tbj02EigyoDaicho.TORIRIEKI + " ");
        sql.append(" ," + Tbj02EigyoDaicho.RIEKIHAIBUN + " ");
        sql.append(" ," + Tbj02EigyoDaicho.NAIKINRIEKI + " ");
        sql.append(" ," + Tbj02EigyoDaicho.FURIKAERIEKI + " ");
        sql.append(" ," + Tbj02EigyoDaicho.EIGYOYOIN + " ");
        sql.append(" ," + Tbj02EigyoDaicho.FURIKAERIEKI2 + " ");
        sql.append(" ," + Tbj02EigyoDaicho.TVTMEDIATANKA + " ");
        sql.append(" ," + Tbj02EigyoDaicho.TVTHMTANKA + " ");
        sql.append(" ," + Tbj02EigyoDaicho.COLORFEE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.DESIGNATIONFEE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.DOUBLEFEE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.RECLASSIFICATIONFEE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SPACEFEE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SPLITRUNFEE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.REQUESTDESTINATION + " ");
        sql.append(" ," + Tbj02EigyoDaicho.BRDDATE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.BIKO + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SEIKYUFLG + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CPDATE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.BRDSEC + " ");
        sql.append(" ," + Tbj02EigyoDaicho.FILEOUTFLG + " ");
        sql.append(" ," + Tbj02EigyoDaicho.APPEARANCEDATE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.SORTNO + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CRTDATE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CRTNM + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CRTAPL + " ");
        sql.append(" ," + Tbj02EigyoDaicho.CRTID + " ");
        sql.append(" ," + Tbj02EigyoDaicho.UPDDATE + " ");
        sql.append(" ," + Tbj02EigyoDaicho.UPDNM + " ");
        sql.append(" ," + Tbj02EigyoDaicho.UPDAPL + " ");
        sql.append(" ," + Tbj02EigyoDaicho.UPDID + " ");
        sql.append(" FROM ");
        sql.append(" " + Tbj02EigyoDaicho.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " = " + _daichoNO + " ");

        return sql.toString();
    }

    /**
     * 営業作業台帳履歴の登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insAccountBookHistory(String daichoNO,String rirekiNm) throws HAMException {

        try {
            _rirekiNm = rirekiNm;
            _daichoNO = daichoNO;
            _ExecSqlMode = ExecSqlMode.INS;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 営業作業台帳履歴の削除を行います
     *
     * @return
     * @throws HAMException データアクセス中にエラーが発生した場合
     */
    public void delAccountBookHistory(String daichoNO) throws HAMException {

        try {
            _daichoNO = daichoNO;
            _ExecSqlMode = ExecSqlMode.DEL;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
