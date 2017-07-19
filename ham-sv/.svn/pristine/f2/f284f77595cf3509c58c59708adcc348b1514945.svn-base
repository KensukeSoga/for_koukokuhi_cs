package jp.co.isid.ham.common.model;

import java.util.List;
import jp.co.isid.ham.integ.tbl.Tbj24LogContractInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 契約情報変更ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・HDX対応(2016/03/01 K.Oki)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj24LogContractInfoDAO extends AbstractSimpleRdbDao {

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, MAX, };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj24LogContractInfoDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj24LogContractInfo.CTRTKBN
                , Tbj24LogContractInfo.CTRTNO
                , Tbj24LogContractInfo.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj24LogContractInfo.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj24LogContractInfo.CRTDATE
                , Tbj24LogContractInfo.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj24LogContractInfo.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj24LogContractInfo.HISTORYKEY
                , Tbj24LogContractInfo.HISTORYNO
                , Tbj24LogContractInfo.HISTORYKBN
                , Tbj24LogContractInfo.CTRTKBN
                , Tbj24LogContractInfo.CTRTNO
                , Tbj24LogContractInfo.DCARCD
                , Tbj24LogContractInfo.CATEGORY
                , Tbj24LogContractInfo.DELFLG
                , Tbj24LogContractInfo.NAMES
                , Tbj24LogContractInfo.DATEFROM
                , Tbj24LogContractInfo.DATETO
                , Tbj24LogContractInfo.MUSIC
                , Tbj24LogContractInfo.JASRACFLG
                , Tbj24LogContractInfo.SALEFLG
                /* 2016/03/01 HDX対応 HLC K.Oki ADD Start */
                , Tbj24LogContractInfo.ENDTITLEFLG
                , Tbj24LogContractInfo.ARRGORGFLG
                /* 2016/03/01 HDX対応 HLC K.Oki ADD End */
                , Tbj24LogContractInfo.BIKO
                , Tbj24LogContractInfo.CRTDATE
                , Tbj24LogContractInfo.CRTNM
                , Tbj24LogContractInfo.CRTAPL
                , Tbj24LogContractInfo.CRTID
                , Tbj24LogContractInfo.UPDDATE
                , Tbj24LogContractInfo.UPDNM
                , Tbj24LogContractInfo.UPDAPL
                , Tbj24LogContractInfo.UPDID
        };
    }


    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAX)) {

            //*******************************************
            //findMaxで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj24LogContractInfo.HISTORYKEY  + "), 0) AS " + Tbj24LogContractInfo.HISTORYKEY + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj24LogContractInfo.TBNAME + " ");

        }

        return sql.toString();
    };

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj24LogContractInfoVO loadVO(Tbj24LogContractInfoVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            _SelSqlMode = SelSqlMode.LOAD;
            return (Tbj24LogContractInfoVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Tbj24LogContractInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * HISTORYKEYの現在の最大値を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj24LogContractInfoVO> findMax(Tbj24LogContractInfoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj24LogContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.MAX;
            return (List<Tbj24LogContractInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public void updateVO(Tbj24LogContractInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK削除
     * @param vo
     * @return
     * @throws HAMException
     */
    public void deleteVO(Tbj24LogContractInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

}
