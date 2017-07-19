package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj41LogTempSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 仮素材登録変更ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj41LogTempSozaiKanriDataDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj41LogTempSozaiKanriDataCondition _condition = null;

    /** SqlMode */
    private enum SqlMode { DEFAULT, FIND, INS, UPD };
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj41LogTempSozaiKanriDataDAO() {
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
                Tbj41LogTempSozaiKanriData.NOKBN
                ,Tbj41LogTempSozaiKanriData.TEMPCMCD
                ,Tbj41LogTempSozaiKanriData.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj41LogTempSozaiKanriData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj41LogTempSozaiKanriData.CRTDATE
                ,Tbj41LogTempSozaiKanriData.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj41LogTempSozaiKanriData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj41LogTempSozaiKanriData.NOKBN
                ,Tbj41LogTempSozaiKanriData.TEMPCMCD
                ,Tbj41LogTempSozaiKanriData.HISTORYNO
                ,Tbj41LogTempSozaiKanriData.CMCD
                ,Tbj41LogTempSozaiKanriData.HISTORYKBN
                ,Tbj41LogTempSozaiKanriData.DELFLG
                ,Tbj41LogTempSozaiKanriData.DCARCD
                ,Tbj41LogTempSozaiKanriData.CATEGORY
                ,Tbj41LogTempSozaiKanriData.TITLE
                ,Tbj41LogTempSozaiKanriData.SECOND
                ,Tbj41LogTempSozaiKanriData.SYATAN
                ,Tbj41LogTempSozaiKanriData.NOHIN
                ,Tbj41LogTempSozaiKanriData.PRODUCT
                ,Tbj41LogTempSozaiKanriData.DATEFROM
                ,Tbj41LogTempSozaiKanriData.DATETO
                ,Tbj41LogTempSozaiKanriData.MLIMIT
                ,Tbj41LogTempSozaiKanriData.KLIMIT
                ,Tbj41LogTempSozaiKanriData.DATERECOG
                ,Tbj41LogTempSozaiKanriData.DATEPRT
                ,Tbj41LogTempSozaiKanriData.BIKO
                ,Tbj41LogTempSozaiKanriData.CRTDATE
                ,Tbj41LogTempSozaiKanriData.CRTNM
                ,Tbj41LogTempSozaiKanriData.CRTAPL
                ,Tbj41LogTempSozaiKanriData.CRTID
                ,Tbj41LogTempSozaiKanriData.UPDDATE
                ,Tbj41LogTempSozaiKanriData.UPDNM
                ,Tbj41LogTempSozaiKanriData.UPDAPL
                ,Tbj41LogTempSozaiKanriData.UPDID
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

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.FIND)) {
            //Tbj41LogTempSozaiKanriDataVO取得用SQL取得
            sql = getSelectSQLTbj41LogTempSozaiKanriDataVO();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj41LogTempSozaiKanriDataVO)
     */
    private String getSelectSQLTbj41LogTempSozaiKanriDataVO() {

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
            Tbj41LogTempSozaiKanriDataVO vo = new Tbj41LogTempSozaiKanriDataVO();
            vo.setNOKBN(_condition.getNokbn());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setHISTORYNO(_condition.getHistoryno());
            vo.setCMCD(_condition.getCmcd());
            vo.setHISTORYKBN(_condition.getHistorykbn());
            vo.setDELFLG(_condition.getDelflg());
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
        orderSql.append(" " + Tbj41LogTempSozaiKanriData.TEMPCMCD);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * insertVO
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {

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
    public void updateVO(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {

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
    public void deleteVO(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {

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
    public List<Tbj41LogTempSozaiKanriDataVO> selectVO(Tbj41LogTempSozaiKanriDataCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj41LogTempSozaiKanriDataVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
