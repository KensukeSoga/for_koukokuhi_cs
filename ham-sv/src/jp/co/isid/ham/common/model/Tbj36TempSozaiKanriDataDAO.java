package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 仮素材登録DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj36TempSozaiKanriDataDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj36TempSozaiKanriDataCondition _condition = null;

    /** SqlMode */
    private enum SqlMode { DEFAULT, FIND, INS, UPD};
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** デフォルトコンストラクタ */
    public Tbj36TempSozaiKanriDataDAO() {
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
                Tbj36TempSozaiKanriData.NOKBN
                ,Tbj36TempSozaiKanriData.TEMPCMCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj36TempSozaiKanriData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlMode.equals(SqlMode.INS)) {
            return new String[] {
                    Tbj36TempSozaiKanriData.CRTDATE
                    ,Tbj36TempSozaiKanriData.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj36TempSozaiKanriData.UPDDATE
            };
        } else {
            return new String[] { };
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj36TempSozaiKanriData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj36TempSozaiKanriData.NOKBN
                ,Tbj36TempSozaiKanriData.TEMPCMCD
                ,Tbj36TempSozaiKanriData.CMCD
                ,Tbj36TempSozaiKanriData.STATUS
                ,Tbj36TempSozaiKanriData.DCARCD
                ,Tbj36TempSozaiKanriData.CATEGORY
                ,Tbj36TempSozaiKanriData.TITLE
                /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
                ,Tbj36TempSozaiKanriData.ALIASTITLE
                ,Tbj36TempSozaiKanriData.ENDTITLE
                ,Tbj36TempSozaiKanriData.DATEFROM_ATTR
                ,Tbj36TempSozaiKanriData.DATETO_ATTR
                /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
                ,Tbj36TempSozaiKanriData.SECOND
                ,Tbj36TempSozaiKanriData.SYATAN
                ,Tbj36TempSozaiKanriData.NOHIN
                ,Tbj36TempSozaiKanriData.PRODUCT
                ,Tbj36TempSozaiKanriData.DATEFROM
                ,Tbj36TempSozaiKanriData.DATETO
                ,Tbj36TempSozaiKanriData.MLIMIT
                ,Tbj36TempSozaiKanriData.KLIMIT
                ,Tbj36TempSozaiKanriData.DATERECOG
                ,Tbj36TempSozaiKanriData.DATEPRT
                ,Tbj36TempSozaiKanriData.BIKO
                ,Tbj36TempSozaiKanriData.CRTDATE
                ,Tbj36TempSozaiKanriData.CRTNM
                ,Tbj36TempSozaiKanriData.CRTAPL
                ,Tbj36TempSozaiKanriData.CRTID
                ,Tbj36TempSozaiKanriData.UPDDATE
                ,Tbj36TempSozaiKanriData.UPDNM
                ,Tbj36TempSozaiKanriData.UPDAPL
                ,Tbj36TempSozaiKanriData.UPDID
        };
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            //Tbj36TempSozaiKanriDataVO取得用SQL取得
            sql = getSelectSQLTbj36TempSozaiKanriDataVO();
        } else if (_sqlMode.equals(SqlMode.FIND)) {
            //仮素材情報取得SQL
            sql = getSelectSQLFind();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj36TempSozaiKanriDataVO)
     */
    private String getSelectSQLTbj36TempSozaiKanriDataVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null) {
            Tbj36TempSozaiKanriDataVO vo = new Tbj36TempSozaiKanriDataVO();
            vo.setNOKBN(_condition.getNokbn());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setCMCD(_condition.getCmcd());
            vo.setSTATUS(_condition.getStatus());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCATEGORY(_condition.getCategory());
            vo.setTITLE(_condition.getTitle());
            vo.setSECOND(_condition.getSecond());
            vo.setSYATAN(_condition.getSyatan());
            vo.setNOHIN(_condition.getNohin());
            vo.setPRODUCT(_condition.getProduct());
            vo.setDATEFROM(_condition.getDatefrom());
            vo.setDATETO(_condition.getDateto());
            vo.setMLIMIT(_condition.getMlimit());
            vo.setKLIMIT(_condition.getKlimit());
            vo.setDATERECOG(_condition.getDaterecog());
            vo.setDATEPRT(_condition.getDateprt());
            vo.setBIKO(_condition.getBiko());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTID(_condition.getCrtid());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
        orderSql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * 仮素材情報取得
     * @return 仮素材情報取得SQL
     */
    private String getSelectSQLFind() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append(getTableColumnNames()[i] + " ");
        }

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD);

        return sql.toString();
    }

    /**
     * insertVO
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj36TempSozaiKanriDataVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.INS;

        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * updateVO
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateVO(Tbj36TempSozaiKanriDataVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.UPD;

        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * deleteVO
     * @param vo 削除VO
     * @throws HAMException
     */
    public void deleteVO(Tbj36TempSozaiKanriDataVO vo) throws HAMException {

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

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj36TempSozaiKanriDataVO> findVO(Tbj36TempSozaiKanriDataCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj36TempSozaiKanriDataVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj36TempSozaiKanriDataVO> selectVO(Tbj36TempSozaiKanriDataCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj36TempSozaiKanriDataVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}