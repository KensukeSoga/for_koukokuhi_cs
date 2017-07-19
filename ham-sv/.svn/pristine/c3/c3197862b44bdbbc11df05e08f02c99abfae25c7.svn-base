package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ番組DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj37RdProgramDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj37RdProgramCondition _condition = null;

    /** SQLモード */
    private enum SqlMode { DEFAULT, FIND, MAX, INS, UPD };
    private SqlMode _sqlMode = SqlMode.FIND;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj37RdProgramDAO() {
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
                Tbj37RdProgram.RDSEQNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj37RdProgram.UPDDATE;
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
                    Tbj37RdProgram.CRTDATE
                    ,Tbj37RdProgram.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj37RdProgram.UPDDATE
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
        return Tbj37RdProgram.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj37RdProgram.RDSEQNO
                ,Tbj37RdProgram.PHASE
                ,Tbj37RdProgram.PROGRAMNM
                ,Tbj37RdProgram.RSDIV
                ,Tbj37RdProgram.NLDIV
                ,Tbj37RdProgram.SECOND
                ,Tbj37RdProgram.TIMES
                ,Tbj37RdProgram.TOTALSECOND
                ,Tbj37RdProgram.DATEFROM
                ,Tbj37RdProgram.DATETO
                ,Tbj37RdProgram.KEYSTATIONCD
                ,Tbj37RdProgram.STARTTIME
                ,Tbj37RdProgram.ENDTIME
                ,Tbj37RdProgram.SALESPRICEDIV
                ,Tbj37RdProgram.SALESPRICE
                ,Tbj37RdProgram.CONFIGPRICEDIV
                ,Tbj37RdProgram.CONFIGPRICE
                ,Tbj37RdProgram.ONAIRMON
                ,Tbj37RdProgram.ONAIRTUE
                ,Tbj37RdProgram.ONAIRWED
                ,Tbj37RdProgram.ONAIRTHU
                ,Tbj37RdProgram.ONAIRFRI
                ,Tbj37RdProgram.ONAIRSAT
                ,Tbj37RdProgram.ONAIRSUN
                ,Tbj37RdProgram.CRTDATE
                ,Tbj37RdProgram.CRTNM
                ,Tbj37RdProgram.CRTAPL
                ,Tbj37RdProgram.CRTID
                ,Tbj37RdProgram.UPDDATE
                ,Tbj37RdProgram.UPDNM
                ,Tbj37RdProgram.UPDAPL
                ,Tbj37RdProgram.UPDID
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
            sql = getSelectSQLTbj37RdProgramVO();
        } else if (_sqlMode.equals(SqlMode.MAX)) {
            sql = getSelectSQLMaxRdSeqNo();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj37RdProgramVO)
     */
    private String getSelectSQLTbj37RdProgramVO() {

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
            Tbj37RdProgramVO vo = new Tbj37RdProgramVO();
            vo.setRDSEQNO(_condition.getRdseqno());
            vo.setPHASE(_condition.getPhase());
            vo.setPROGRAMNM(_condition.getProgramnm());
            vo.setRSDIV(_condition.getRsdiv());
            vo.setNLDIV(_condition.getNldiv());
            vo.setSECOND(_condition.getSecond());
            vo.setTIMES(_condition.getTimes());
            vo.setTOTALSECOND(_condition.getTotalsecond());
            vo.setDATEFROM(_condition.getDatefrom());
            vo.setDATETO(_condition.getDateto());
            vo.setKEYSTATIONCD(_condition.getKeystationcd());
            vo.setSTARTTIME(_condition.getStarttime());
            vo.setENDTIME(_condition.getEndtime());
            vo.setSALESPRICEDIV(_condition.getSalespricediv());
            vo.setSALESPRICE(_condition.getSalesprice());
            vo.setCONFIGPRICEDIV(_condition.getConfigpricediv());
            vo.setCONFIGPRICE(_condition.getConfigprice());
            vo.setONAIRMON(_condition.getOnairmon());
            vo.setONAIRTUE(_condition.getOnairtue());
            vo.setONAIRWED(_condition.getOnairwed());
            vo.setONAIRTHU(_condition.getOnairthu());
            vo.setONAIRFRI(_condition.getOnairfri());
            vo.setONAIRSAT(_condition.getOnairsat());
            vo.setONAIRSUN(_condition.getOnairsun());
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
        orderSql.append(" " + Tbj37RdProgram.RDSEQNO);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * SELECT SQL(最大ラジオ番組SEQNO取得)
     * @return
     */
    private String getSelectSQLMaxRdSeqNo() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        sql.append(" NVL(MAX(" + Tbj37RdProgram.RDSEQNO + "), 0) + 1 " + Tbj37RdProgram.RDSEQNO);

        sql.append(" FROM");
        sql.append(" " + Tbj37RdProgram.TBNAME);

        return sql.toString();
    };

    /**
     * insertVO
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj37RdProgramVO vo) throws HAMException {

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
    public void updateVO(Tbj37RdProgramVO vo) throws HAMException {

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
    public void deleteVO(Tbj37RdProgramVO vo) throws HAMException {

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
     * ラジオ番組SEQNO最大値取得
     * @param condition 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj37RdProgramVO> selectMaxRdSeqNo(Tbj37RdProgramCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj37RdProgramVO());
        _condition = condition;
        _sqlMode = SqlMode.MAX;

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
    public List<Tbj37RdProgramVO> selectVO(Tbj37RdProgramCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj37RdProgramVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
