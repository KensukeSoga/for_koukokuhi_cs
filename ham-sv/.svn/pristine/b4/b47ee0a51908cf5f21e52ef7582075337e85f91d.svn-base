package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材登録DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・JASRAC対応(2015/10/31 HLC S.Fujimoto)
 * ・HDX対応(2016/02/17 HLC K.Soga)
 * </P>
 * @author 新HAMチーム
 */
public class Tbj18SozaiKanriDataDAO extends AbstractSimpleRdbDao {

    private enum StoreMode {INS, UPD};
    private StoreMode _StoreMode = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{MULTIPK,};
    private SelSqlMode _SelSqlMode = null;

    /** 検索条件 */
    private List<Tbj18SozaiKanriDataVO> _conditions = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj18SozaiKanriDataDAO() {
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
                Tbj18SozaiKanriData.NOKBN
                ,Tbj18SozaiKanriData.CMCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj18SozaiKanriData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (StoreMode.INS.equals(_StoreMode)) {
            return new String[] {
                    Tbj18SozaiKanriData.CRTDATE
                    ,Tbj18SozaiKanriData.UPDDATE
            };
        } else if (StoreMode.UPD.equals(_StoreMode)) {
            return new String[] {
                    Tbj18SozaiKanriData.UPDDATE
            };
        } else {
            return new String[] {};
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj18SozaiKanriData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj18SozaiKanriData.NOKBN
                ,Tbj18SozaiKanriData.CMCD
                ,Tbj18SozaiKanriData.STATUS
                ,Tbj18SozaiKanriData.DCARCD
                ,Tbj18SozaiKanriData.CATEGORY
                ,Tbj18SozaiKanriData.TITLE
                /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
                ,Tbj18SozaiKanriData.ALIASTITLE
                ,Tbj18SozaiKanriData.ENDTITLE
                ,Tbj18SozaiKanriData.DATEFROM_ATTR
                ,Tbj18SozaiKanriData.DATETO_ATTR
                /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
                ,Tbj18SozaiKanriData.SECOND
                ,Tbj18SozaiKanriData.SYATAN
                ,Tbj18SozaiKanriData.NOHIN
                ,Tbj18SozaiKanriData.PRODUCT
                ,Tbj18SozaiKanriData.DATEFROM
                ,Tbj18SozaiKanriData.DATETO
                ,Tbj18SozaiKanriData.MLIMIT
                ,Tbj18SozaiKanriData.KLIMIT
                ,Tbj18SozaiKanriData.DATERECOG
                ,Tbj18SozaiKanriData.DATEPRT
                ,Tbj18SozaiKanriData.BIKO
                ,Tbj18SozaiKanriData.CRTDATE
                ,Tbj18SozaiKanriData.CRTNM
                ,Tbj18SozaiKanriData.CRTAPL
                ,Tbj18SozaiKanriData.CRTID
                ,Tbj18SozaiKanriData.UPDDATE
                ,Tbj18SozaiKanriData.UPDNM
                ,Tbj18SozaiKanriData.UPDAPL
                ,Tbj18SozaiKanriData.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        String sql = "";
        if (SelSqlMode.MULTIPK.equals(_SelSqlMode)) {
            sql = getSelectSQLForMultiPK();
        } else {
            sql = getSelectSQLForItem();
        }
        return sql;
    }

    private String getSelectSQLForMultiPK() {

        StringBuffer sql = new StringBuffer();

        // *******************************************
        // 排他用SQL
        // *******************************************
        sql.append(" SELECT ");
        sql.append(" " + getTimeStampKeyName() + " ");
        for (int i = 0; i < getPrimryKeyNames().length; i++) {
            sql.append(" ," + getPrimryKeyNames()[i] +" ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        for (int i = 0; i < _conditions.size(); i++) {
            AbstractModel cond = _conditions.get(i);
            sql.append((i != 0 ? " OR " : " "));
            sql.append(" ( ");
            for (int j = 0; j < getPrimryKeyNames().length; j++) {
                sql.append((j != 0 ? " AND " : " "));
                sql.append("" + getPrimryKeyNames()[j] +" ");
                sql.append(" = ");
                sql.append(getDBModelInterface().ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
            }
            sql.append(" ) ");
        }

        return sql.toString();
    }

    private String getSelectSQLForItem() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
        sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
        sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
        sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
        sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
        sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
        sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDID);
        sql.append(" FROM ");
        sql.append("  " + Tbj18SozaiKanriData.TBNAME);

        return sql.toString();
    }

    /**
     * 素材登録テーブルの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> Tbj18SozaiKanriDataByCondition(Tbj18SozaiKanriDataCondition cond) throws HAMException {

        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * PKを条件にして検索を行います(複数指定可)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> selectByMultiPk(List<Tbj18SozaiKanriDataVO> cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.MULTIPK;
            _conditions = cond;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj18SozaiKanriDataVO loadVO(Tbj18SozaiKanriDataVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj18SozaiKanriDataVO)super.load();
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
    public void insertVO(Tbj18SozaiKanriDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.INS;
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public void updateVO(Tbj18SozaiKanriDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.UPD;
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
    public void deleteVO(Tbj18SozaiKanriDataVO vo) throws HAMException {
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
